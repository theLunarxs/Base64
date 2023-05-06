using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Base64.Utility
{
    public class APIService
    {
        private readonly string _APIAddress;
        public APIService(string APIAddress)
        {
            _APIAddress = APIAddress;
        }

        public async Task<string[]> GetALLIPAddressAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_APIAddress}/");
            var content = await response.Content.ReadAsStringAsync();
            HashSet<string> IPlist = new(content.Contains(',') ? content.Split(",") : content.Split(' '));
            return IPlist.ToArray();
        }
        public async Task<string[]> GetAllIPAddressesISPAsync(string ISP)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_APIAddress}/GetAllIPsISP/{ISP}");
            var content = await response.Content.ReadAsStringAsync();
            HashSet<string> IPlist = new(content.Contains(',') ? content.Split(",") : content.Split(' '));
            return IPlist.ToArray();
        }
        public async Task<string[]> GetIPAddressesToScanAsync(string ISP)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_APIAddress}/ToScan/{ISP}");
            var content = await response.Content.ReadAsStringAsync();
            HashSet<string> IPlist = new(content.Contains(',') ? content.Split(",") : content.Split(' '));
            return IPlist.ToArray();
        }
        public async Task<string[]> GetIPAddressesForConfigAsync(string ISP, int Count)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_APIAddress}/forConfig/{ISP}/{Count}");
            var content = await response.Content.ReadAsStringAsync();
            HashSet<string> IPlist = new(content.Contains(',') ? content.Split(",") : content.Split(' '));
            return IPlist.ToArray();
        }
        public async Task<bool> SendIPAddressesAsync(JsonObject data)
        {
            try
            {
                var httpClient = new HttpClient();

                var content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"{_APIAddress}/process_data", content);

                return true;
            }

            catch
            {
                return false;
            }
        }
    }
}