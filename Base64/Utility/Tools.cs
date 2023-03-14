using Renci.SshNet;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json.Linq;
using Base64.Utility.Models;
using Base64.Utility;
using Newtonsoft.Json;
using Microsoft.VisualBasic.ApplicationServices;
using System.Text.Json;

namespace Base64.Utility
{
    public static class Tools
    {
        public struct Server
        {
            public string IP;
            public string Port;
            public string Username;
            public string Password;
        }

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

        public static async Task<string> WriteToFileAsync(string path, string text, bool append, bool unique, bool useNumberAndLetter)
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

                return newFilePath;
            }
            catch (Exception ex)
            {
                throw new IOException($"Error writing file text:{Environment.NewLine}{ex.Message}");
            }
        }

        public static async Task<string> WriteToFileAsync(string path, string text, string Seedname, bool unique, bool useNumberAndLetter)
        {
            try
            {
                var name = Seedname;

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

                var newFilePath = Path.Combine(path, name + ".txt");

                await File.WriteAllTextAsync(newFilePath, text + Environment.NewLine);

                return newFilePath;
            }
            catch (Exception ex)
            {
                throw new IOException($"Error writing file text:{Environment.NewLine}{ex.Message}");
            }
        }


        public static async Task<string> FetchDBFromServer(Server Server)
        {
            var connectionInfo = new ConnectionInfo(Server.IP, int.Parse(Server.Port), Server.Username,
                new PasswordAuthenticationMethod(Server.Username, Server.Password));

            using (var sftpClient = new SftpClient(connectionInfo))
            {
                try
                {
                    sftpClient.Connect();
                    Debug.WriteLine("SFTP Connected");

                    // Download file from remote server
                    using (var fileStream = File.Create(@"P:\sshkey\test1.db"))
                    {
                        try
                        {
                            sftpClient.DownloadFile("/etc/x-ui/x-ui.db", fileStream);
                            Debug.WriteLine("File downloaded");
                        }
                        catch
                        {
                            Debug.WriteLine("Failed to download file");
                        }
                    }

                    sftpClient.Disconnect();
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(ex.Message);
                }

            }
            Debug.WriteLine("Disconnected");

            return await Task.FromResult("Success");
        }

        public static List<InboundModel> GetInbounds()
        {
            using (var context = new ConfigsContext())
            {
                var inbounds = context.Inbounds.ToList();
                if (inbounds.Any())
                {
                    return inbounds;
                }
                throw new NullReferenceException();
            }
        }
        // Encode Section \\


        // IP Section \\
        public static string GetIPAddress(InboundModel inbound)
        {
            string json = inbound.StreamSettings;
            var jObject = JObject.Parse(json);

            // Access the "Host" value inside the "headers" object
            string host = jObject["wsSettings"]!["headers"]!["Host"]!.Value<string>()!;
            return host;
        }
        public static string GetSNI(InboundModel inbound)
        {
            string json = inbound.StreamSettings;
            var jObject = JObject.Parse(json);

            // Access the "serverName" value inside the "tlsSettings" object
            string sni = jObject["tlsSettings"]!["serverName"]!.Value<string>()!;
            return sni;
        }
        public static string GetID(InboundModel inbound)
        {
            string json = inbound.StreamSettings;
            JsonDocument JDOC = JsonDocument.Parse(json);
            string ID = JDOC.RootElement
                .GetProperty("clients")[0]
                .GetProperty("id")
                .GetString()!;
            return ID;
        }
        public static List<List<InboundModel>> PermutateIPS(List<InboundModel> inbounds, List<string> IPs)
        {
            /*
This function takes in a list of inbound objects and a list of IP addresses.
It then generates all the possible combinations of the inbound objects with the given IP addresses.
The function uses LINQ to generate the combinations by iterating over the inbound objects and for each object,
it creates new inbound objects by replacing the IP address in the StreamSettings field with each IP address in the given list.
The new inbound objects are then added to a list of lists, where each inner list represents a combination of the inbound objects with a particular IP address.
Finally, the function returns the list of all combinations.
*/
            var resInbounds = new List<List<InboundModel>>();

            foreach (var inbound in inbounds)
            {
                var newInbounds = IPs.Select(ip =>
                {
                    var newInbound = new InboundModel
                    {
                        Id = inbound.Id,
                        UserId = inbound.UserId,
                        Up = inbound.Up,
                        Down = inbound.Down,
                        Total = inbound.Total,
                        Remark = inbound.Remark,
                        Enable = inbound.Enable,
                        ExpiryTime = inbound.ExpiryTime,
                        Listen = inbound.Listen,
                        Port = inbound.Port,
                        Protocol = inbound.Protocol,
                        Settings = inbound.Settings,
                        StreamSettings = inbound.StreamSettings.Replace(GetIPAddress(inbound), ip),
                        Tag = inbound.Tag,
                        Sniffing = inbound.Sniffing
                    };
                    return newInbound;
                }).ToList();
                resInbounds.Add(newInbounds);
            }
            return resInbounds;
        }

        public static string VmessEncoder(InboundModel inbound)
        {
            var VmessLink = System.Text.Json.JsonSerializer.Serialize(new VmessBase64Model
            {
                v = "2",
                ps = inbound.Remark,
                add = GetIPAddress(inbound),
                port = inbound.Port,
                id = GetID(inbound),
                aid = 0,
                scy = "auto",
                net = "ws",
                type = "none",
                path = $"/wss{inbound.Port}",
                tls = "tls",
                sni = GetSNI(inbound),
                alpn = ""
            });
            return ConvertToBase64(VmessLink, false);
        }
        public static VlessModel VlessObjGenerator(InboundModel inbound)
        {
            var VlessObject = new VlessModel
            {
                UUID = GetID(inbound),
                Address = GetIPAddress(inbound),
                Port = inbound.Port,
                type = "ws",
                security = "tls",
                path = $"/wss{inbound.Port}",
                host = GetSNI(inbound),
                SNI = GetSNI(inbound),
                Remark = "#" + inbound.Remark
            };
            return VlessObject;
        }
        public static string ToVlessLink(this VlessModel VlessObject)
        {
            return $"vless://{VlessObject.UUID}@{VlessObject.Address}:{VlessObject.Port}?sni={VlessObject.SNI}&security={VlessObject.security}&type={VlessObject.type}" +
                $"&path={VlessObject.path}&host={VlessObject.host}{VlessObject.Remark}";
        }
    }
}