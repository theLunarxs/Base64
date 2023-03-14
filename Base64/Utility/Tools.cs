using Renci.SshNet;
using System.Diagnostics;
using System.Text;
using Base64.Utility.Models;
using System.Text.Json;
using static Base64.Utility.Tools;
using Newtonsoft.Json.Linq;

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

        public struct Configuration
        {
            public string path;
            public string text; // raw Input
            public bool unique;
            public bool useNumberAndLetter;
            public bool SeperatePermutations;
            public string IPFilePath;
            public string Seedname;
            public bool IPsection;
        }

        public static string ConvertToBase64(List<string> input)
        {
            List<string> Final = new List<string>(input.Count);

            foreach (string s in input)
            {
                byte[] toByte = Encoding.UTF8.GetBytes(s);
                string encoded = Convert.ToBase64String(toByte);
                Final.Add(encoded);
            }

            return string.Join(Environment.NewLine, Final);
        }

        //public static async Task<bool> MakeitWork(Server server, Configuration config)
        //{
        //    List<string> result = new();
        //    int count = 1;
        //    try
        //    {
        //        List<InboundModel> inbounds = Database.FetchDBFromServer(server).GetInbounds();

        //        if (config.IPsection)
        //        {
        //            List<string> IPList = await config.IPFilePath.ToIPList();
        //            List<List<InboundModel>> PermutatedInbounds = Inbound.PermutateIPS(inbounds, IPList);

        //            if (config.SeperatePermutations)
        //            {
        //                count = IPList.Count;
        //            }
        //            inbounds = PermutatedInbounds.SelectMany(x => x).ToList();
        //        }

        //        foreach (InboundModel inbound in inbounds)
        //        {
        //            if (inbound.Protocol == "vmess")
        //            {
        //                result.Add(Inbound.VmessEncoder(inbound));
        //            }
        //            else if (inbound.Protocol == "vless")
        //            {
        //                result.Add(Inbound.VlessObjGenerator(inbound).ToVlessLink());
        //            }
        //        }
        //        if (config.SeperatePermutations)
        //        {
        //            for (int x = 0; x < result.Count; x += count)
        //            {
        //                List<string> SeperatedConfigs = result.GetRange(x, count);
        //                string EncodedConfigs = ConvertToBase64(result);
        //                await IO.WriteToFileAsync(EncodedConfigs, config);

        //            }
        //            return true;
        //        }
        //        string EncodedLinks = ConvertToBase64(result);
        //        await IO.WriteToFileAsync(EncodedLinks, config);

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        public static bool TestConnection(Server ClientServer)
        {
            var connectionInfo = new ConnectionInfo(ClientServer.IP, int.Parse(ClientServer.Port), ClientServer.Username,
                                        new PasswordAuthenticationMethod(ClientServer.Username, ClientServer.Password));
            bool Success;
            using (var conn = new SshClient(connectionInfo))
            {
                try
                {
                    conn.Connect();
                    Success = conn.IsConnected;
                    conn.Disconnect();
                }
                catch
                {
                    conn.Disconnect();
                    return false;
                }
                return Success;
            }
        }
        public static async Task<bool> MakeitWork(Server ClientServer, Configuration config)
        {
            List<string> result = new();
            try
            {
                List<InboundModel> inbounds = Database.FetchDBFromServer(ClientServer).GetInbounds();

                if (config.IPsection)
                {
                    List<string> IPList = await config.IPFilePath.ToIPList();
                    List<List<InboundModel>> PermutatedInbounds = Inbound.PermutateIPS(inbounds, IPList);

                    if (config.SeperatePermutations)
                    {
                        for (int i = 0; i < PermutatedInbounds.Count; i++)
                        {
                            List<string> links = PermutatedInbounds[i]
                                .Select(inbound => inbound.Protocol == "vmess" ? Inbound.VmessEncoder(inbound) : Inbound.VlessObjGenerator(inbound).ToVlessLink())
                                .ToList();
                            string encodedLinks = ConvertToBase64(links);
                            await IO.WriteToFileAsync(encodedLinks, config);
                        }
                        return true;
                    }
                    inbounds = PermutatedInbounds.SelectMany(x => x).ToList();
                }

                foreach (InboundModel inbound in inbounds)
                {
                    if (inbound.Protocol == "vmess")
                    {
                        result.Add(Inbound.VmessEncoder(inbound));
                    }
                    else if (inbound.Protocol == "vless")
                    {
                        result.Add(Inbound.VlessObjGenerator(inbound).ToVlessLink());
                    }
                }

                string EncodedLinks = ConvertToBase64(result);
                await IO.WriteToFileAsync(EncodedLinks, config);

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
    public static class IO
    {
        public static async Task<string> WriteToFileAsync(string text, Configuration config)
        {
            try
            {
                var name = config.Seedname;

                if (config.unique)
                {
                    var random = new Random();
                    var chars = config.useNumberAndLetter ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" : "0123456789";
                    var randomString = new string(
                        Enumerable.Repeat(chars, 8)
                        .Select(s => s[random.Next(s.Length)])
                        .ToArray());
                    name += randomString;
                }
                var newFilePath = Path.Combine(config.path, name + ".txt");

                await File.WriteAllTextAsync(newFilePath, text + Environment.NewLine);

                return newFilePath;
            }
            catch (Exception ex)
            {
                throw new IOException($"Error writing file text:{Environment.NewLine}{ex.Message}");
            }
        }
    }
    public static class Database
    {
        public static bool FetchDBFromServer(Server ClientServer)
        {
            var connectionInfo = new ConnectionInfo(ClientServer.IP, int.Parse(ClientServer.Port), ClientServer.Username,
                new PasswordAuthenticationMethod(ClientServer.Username, ClientServer.Password));

            using (var sftpClient = new SftpClient(connectionInfo))
            {
                try
                {
                    sftpClient.Connect();
                    Debug.WriteLine("SFTP Connected");

                    // Download file from remote server
                    using (var fileStream = File.Create(@"DB\yourDB.db"))
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
                catch
                {
                    return false;
                }
            }
            Debug.WriteLine("Disconnected");

            return true;
        }
    }
    public static class Inbound
    {
        public static List<InboundModel> GetInbounds(this bool success)
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
        #region Encode
        // Encode Section \\
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
            return "vmess://" + VmessLink;
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
        // End Section \\
        #endregion
        // IP Section \\
        public static async Task<List<string>> ToIPList(this string path)
        {
            List<string> IPs = new();
            string content;

            using (StreamReader reader = new(path))
            {
                content = await reader.ReadToEndAsync();
            }
            var IPlist = content.Contains(',') ? content.Split(",") : content.Split(' ');

            IPs.AddRange(IPlist);
            return IPs;
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

    }
    public static class Visual
    {
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

    }
}