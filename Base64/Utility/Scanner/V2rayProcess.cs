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
        private readonly string _V2rayExePath = @"\V2ray\V2ray.exe";
        private ProcessStartInfo _startInfo;
        private Process _process;
        private int _downloadTimeout;
        private float _downloadDuration;
        private double _targetSpeed;

        public V2rayProcess()
        {
            _startInfo.FileName = _V2rayExePath;
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
        public bool Start(string ConfigPath)
        {
            _startInfo.Arguments = $"run -config=\"{ConfigPath}\"";

            _process = Process.Start(_startInfo)!;

            Thread.Sleep(1500);

            return _process.Responding && !_process.HasExited;
        }
        private async Task<bool> CheckDownloadSpeed(int port)
        {
            var proxy = new WebProxy();
            proxy.Address = new Uri($"socks5://127.0.0.1:{port}");
            var handler = new HttpClientHandler
            {
                Proxy = proxy
            };

            int timeout = _downloadTimeout;

            var client = new HttpClient(handler);
            client.Timeout = TimeSpan.FromSeconds(timeout); // 2 seconds
            Stopwatch sw = new Stopwatch();

            try
            {
                sw.Start();
                string dlUrl = "https://speed.cloudflare.com/__down?bytes=" + (_targetSpeed * 1000 * _downloadTimeout);

                var data = await client.GetStringAsync(dlUrl);

                return data.Length == _targetSpeed * 1000 * _downloadTimeout;
            }

            catch
            {
                return false;
            }

            finally
            {
                _downloadDuration = sw.ElapsedMilliseconds;
                if (_downloadDuration > (timeout * 1000) + 500)
                {

                }
                handler.Dispose();
                client.Dispose();
            }
        }
    }
}
