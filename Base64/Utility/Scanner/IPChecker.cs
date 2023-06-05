using System.Diagnostics;
using System.Net.NetworkInformation;
using static Base64.Utility.Scanner.Configurations;
using static Base64.Utility.Scanner.V2rayProcess;

namespace Base64.Utility.Scanner
{
    public class IPChecker
    {
        private readonly string _IP;
        private readonly int _port;
        private readonly ClientConfig _clientConfig;
        private long frontingDuration;
        private V2rayProcessConfig _processConfig;
        public readonly string ClientConfigPath;
        public V2rayProcess v2rayProcess;

        public IPChecker(ClientConfig ClientConfig, CheckIPConfigurations checkIPConfig)
        {
            _IP = ClientConfig.currentIP;
            _port = GenerateRandomPortFromGivenIP(_IP);
            _clientConfig = ClientConfig;
            ClientConfigPath = _clientConfig.ClientConfigPath;

            _processConfig._targetDLSpeed = checkIPConfig.targetDownloadSpeed;
            _processConfig._targetUPSpeed = checkIPConfig.targetUploadSpeed;
            _processConfig._downloadTimeout = checkIPConfig.timeoutSec;
            _processConfig._targetVolume = checkIPConfig.checkTargetVolume;
        }

        public bool CheckIPWorking(bool speedtest)
        {
            // we always check fronting
            bool frontingSuccess = CheckFronting();
            // if CheckSpeed Was Requested, we also check the speed 
            if (frontingSuccess && speedtest)
            {
                bool result = speedtest ? CheckIP().Result : frontingSuccess;

                return result;
            }

            return frontingSuccess;
        }

        private async Task<bool> CheckIP()
        {
            v2rayProcess = new(_processConfig);
            var res = await v2rayProcess.Start(_clientConfig.ClientConfigPath, _port);
            return res;
        }

        private bool CheckFronting(bool withCustumDNSResolver = true, int timeout = 1)
        {
            DnsHandler dnsHandler;
            HttpClient client;

            if (withCustumDNSResolver)
            {
                dnsHandler = new DnsHandler(new CustomDnsResolver(_IP));
                client = new HttpClient(dnsHandler);
            }
            else
            {
                client = new HttpClient();
            }

            client.Timeout = TimeSpan.FromSeconds(timeout);
            Stopwatch sw = new();

            try
            {

                string frUrl = "https://speed.cloudflare.com/__down?bytes=1000";
                sw.Start();
                var html = client.GetStringAsync(frUrl).Result;
                frontingDuration = sw.ElapsedMilliseconds;
                return html.StartsWith("0000000000");
            }

            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                client.Dispose();
            }
        }
        private static int GenerateRandomPortFromGivenIP(string IP)
        {
            int sum = Int32.Parse(
                IP.Split(".").Aggregate((current, next) =>
                          (Int32.Parse(current) + Int32.Parse(next)).ToString()));

            return 3000 + sum;
        }

    }
}
