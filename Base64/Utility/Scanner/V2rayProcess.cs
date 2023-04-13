using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Base64.Utility.Scanner
{
    public class V2rayProcess
    {
        private string V2rayExePath = "";
        private ProcessStartInfo startInfo;
        private Process process;
        private int downloadTimeout;
        private float downloadDuration;
        private double targetSpeed;

        public V2rayProcess(ClientConfig Config) 
        {
            startInfo.FileName = V2rayExePath;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            process = new Process();
        }
        public bool Start(string ConfigPath)
        { 
            startInfo.Arguments = $"run -config=\"{ConfigPath}\"";

            process = Process.Start(startInfo)!;

            Thread.Sleep(1500);

            return process.Responding && !process.HasExited;
        }
        private bool checkDownloadSpeed(int port)
        {
            var proxy = new WebProxy();
            proxy.Address = new Uri($"socks5://127.0.0.1:{port}");
            var handler = new HttpClientHandler
            {
                Proxy = proxy
            };

            int timeout = downloadTimeout;

            var client = new HttpClient(handler);
            client.Timeout = TimeSpan.FromSeconds(timeout); // 2 seconds
            Stopwatch sw =  new Stopwatch();
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            try
            {
                sw.Start();
                string dlUrl = "https://speed.cloudflare.com/__down?bytes=" + (targetSpeed * 1000 * downloadTimeout);
                var data = client.GetStringAsync(dlUrl).Result;

                return data.Length == (targetSpeed * 1000 * downloadTimeout) * timeout;
            }
            finally
            {
                downloadDuration = sw.ElapsedMilliseconds;
                if(downloadDuration > (timeout * 1000) + 500)
                {

                }
                handler.Dispose();
                client.Dispose();
            }
        }
    }
}
