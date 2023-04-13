namespace Base64.Utility
{
    public class API
    {
        public static async Task<string[]> GetIPAddressAsync(string APIAddress)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(APIAddress);
            var content = await response.Content.ReadAsStringAsync();
            var IPlist = content.Contains(',') ? content.Split(",") : content.Split(' ');
            return IPlist;
        }
    }
}