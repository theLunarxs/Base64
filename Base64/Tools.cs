using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Renci.SshNet;

namespace Base64
{
    public static class Tools
    {
        public static string ConvertToBase64(string input, bool ios)
        {
            string[] raw = ios ? input.Split('\v') : new string[] { input };
            string[] Final = new string[raw.Length];

            for (int i = 0; i < raw.Length; i++)
            {
                // Convert the string to a byte array using the UTF-8 encoding
                byte[] toByte = Encoding.UTF8.GetBytes(raw[i]);

                // Convert the byte array to a Base64-encoded string using the Convert.ToBase64String method
                string encoded = Convert.ToBase64String(toByte);

                Final[i] = encoded;

            }

            return string.Join(Environment.NewLine, Final); ;
        }

        public static void MakeLabelGo(int interval, Label label)
        {
            // Create a new timer
            System.Threading.Timer timer = null;

            // Set the callback function to disable the label
            TimerCallback callback = state =>
            {
                label.Invoke(new Action(() =>
                {
                    label.Visible = false;
                }));

                // Dispose of the timer
                timer.Dispose();
            };

            // Start the timer
            timer = new System.Threading.Timer(callback, null, interval, Timeout.Infinite);
        }

        public static async Task WriteToFileAsync(string path, string text, bool append, bool unique, bool useNumberAndLetter)
        {
            try
            {
                var name = Path.GetFileNameWithoutExtension(path);

                if (unique)
                {
                    var random = new Random();
                    var chars = useNumberAndLetter ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" : "0123456789";
                    var randomString = new string(
                        Enumerable.Repeat(chars, 8)
                        .Select(s => s[random.Next(s.Length)])
                        .ToArray());
                    name += randomString;
                }

                var extension = Path.GetExtension(path);
                var directory = Path.GetDirectoryName(path);
                var newFilePath = Path.Combine(directory!, name + extension);


                if (append)
                {
                    using (StreamReader reader = new(path))
                    {
                        text = await reader.ReadToEndAsync() + Environment.NewLine + text;
                    }
                }

                await File.WriteAllTextAsync(newFilePath, text + Environment.NewLine);

            }
            catch (Exception ex)
            {
                throw new IOException($"Error writing file text: {Environment.NewLine}{ex.Message}");
            }
        }
        public static async Task<bool> FetchDBFromServer(string IP, string Username, string Password)
        {
            ConnectionInfo conInfo = new(IP, Username, new PasswordAuthenticationMethod(Username, Password));

            using (SshClient sshClient = new(conInfo))
            {
                try
                {
                    // Connecting to Server and Fetching DB
                    sshClient.Connect();

                    // Using SFTPClient to Download DB to Path
                    using (var sftpClient = new SftpClient(sshClient.ConnectionInfo))
                    {
                        sftpClient.Connect();

                        // Download file from remote server
                        using (var fileStream = File.Create(@"C:\temp\users.db"))
                        {
                            sftpClient.DownloadFile("/opt/freedom/x-ui/db/x-ui.db", fileStream);
                        }

                        sftpClient.Disconnect();
                    }

                    sshClient.Disconnect();

                    return await Task.FromResult(true);
                }
                catch
                {
                    return await Task.FromResult(false);
                }
            }
        }
        public static async Task<List<string>> DBtoList(string path)
        {
            
        }
    }
}
