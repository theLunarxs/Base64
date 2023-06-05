using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using static Base64.Utility.Scanner.Configurations;

namespace Base64.Utility.Scanner
{
    public class V2rayProcess
    {
        //private readonly string _downURLbroad = "http://ipv4.download.thinkbroadband.com/5MB.zip";
        private readonly string _downloadURLCF = "https://speed.cloudflare.com/__down?bytes=";
        private const string _CalcPingDestination = "EnterURLHere";
        private const string _V2rayExePath = @"\V2ray\V2ray.exe";
        private readonly ProcessStartInfo _startInfo;
        private Process _process;
        private double _downloadTimeout;
        private float _downloadDuration;
        private double _targetDLSpeed;
        private double _targetUPSpeed;
        private readonly int _targetVolumeToDownload;
        public double DownloadSpeed;
        public double UploadSpeed;
        public int Ping;
        private const string SpeedTestApiUrl = "https://www.speedtest.net/api/js/servers";

        public V2rayProcess(V2rayProcessConfig processConfig)
        {
            _downloadTimeout = processConfig._downloadTimeout;
            _targetDLSpeed = processConfig._targetDLSpeed;
            _targetUPSpeed = processConfig._targetUPSpeed;
            _targetVolumeToDownload = processConfig._targetVolume;
            _startInfo!.FileName = _V2rayExePath;
            _startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            _startInfo.RedirectStandardOutput = true;
            _startInfo.RedirectStandardError = true;
            _startInfo.CreateNoWindow = true;
            _startInfo.UseShellExecute = false;
            _process = new Process();
        }

        ~V2rayProcess()
        {
            _process.Kill();
        }

        public async Task<bool> Start(string ConfigPath, int Port)
        {
            _startInfo.Arguments = $"run -config=\"{ConfigPath}\"";

            _process = Process.Start(_startInfo)!;

            Thread.Sleep(1500);

            if (_process.Responding && !_process.HasExited)
            {
                // TODO: make Calculate ping usse SOCKS proxy 
                return CheckDownloadSpeed(Port).Result && CheckUploadSpeed(Port).Result && CalculatePing(_CalcPingDestination);
            }
            return false;
        }

        private async Task<bool> CheckDownloadSpeed(int port)
        {
            string dlUrl = _downloadURLCF + _targetVolumeToDownload.ToString();

            WebProxy proxy = new WebProxy($"socks5://127.0.0.1:{port}");

            HttpClientHandler handler = new HttpClientHandler
            {
                Proxy = proxy
            };

            using (HttpClient client = new HttpClient(handler))
            {
                client.Timeout = TimeSpan.FromSeconds(_downloadTimeout); // 2 seconds

                Stopwatch sw = new Stopwatch();

                try
                {
                    sw.Start();
                    byte[] data = await client.GetByteArrayAsync(dlUrl);
                    sw.Stop();
                    var speed = _targetVolumeToDownload / sw.Elapsed.TotalSeconds;
                    bool result = data.Length == _targetVolumeToDownload && sw.Elapsed.Seconds <= _downloadDuration && speed >= _targetDLSpeed;
                    DownloadSpeed = speed;
                    if (DownloadSpeed >= 0)
                        return result;
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        private async Task<bool> CheckUploadSpeed(int port)
        {
            UploadSpeed = 0.00;
            return true;
        }

        private bool CalculatePing(string Destination)
        {
            try
            {
                using (Ping pingSender = new Ping())
                {
                    PingReply reply = pingSender.Send(Destination);

                    if (reply.Status == IPStatus.Success)
                    {
                        Ping = Convert.ToInt32(reply.RoundtripTime);
                        return true;
                    }
                    else
                    {
                        // Ping failed, handle the failure case here
                        Ping = -1;
                        return false;
                    }
                }
            }
            catch (PingException)
            {
                // Ping exception occurred, handle the exception case here
                return false;
            }
        }
    }
}
