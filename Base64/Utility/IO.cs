using static Base64.Utility.Tools;
using static Base64.Utility.Configuration;

namespace Base64.Utility
{
    public static class IO
    {
        public static async Task<string> WriteToFileAsync(string text, Configuration config)
        {
            try
            {
                var name = config.IOconfig.Seedname;

                if (config.IOconfig.unique)
                {
                    var random = new Random();
                    var chars = config.IOconfig.useNumberAndLetter ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" : "0123456789";
                    var randomString = new string(
                        Enumerable.Repeat(chars, 8)
                        .Select(s => s[random.Next(s.Length)])
                        .ToArray());
                    name += randomString;
                }
                var newFilePath = Path.Combine(config.IOconfig.path, name + ".txt");

                await File.WriteAllTextAsync(newFilePath, text + Environment.NewLine);

                return newFilePath;
            }
            catch (Exception ex)
            {
                throw new IOException($"Error writing file text:{Environment.NewLine}{ex.Message}");
            }
        }
    }
}