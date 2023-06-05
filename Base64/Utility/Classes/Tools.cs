using Base64.Utility.Models;
using Renci.SshNet;
using System.Text;
using static Base64.Utility.Classes.Configuration;

namespace Base64.Utility.Classes
{
    public static class Tools
    {

        public static string ConvertToBase64(List<string> input, Configuration config)
        {
            byte[] toByte;
            string encoded;
            var result = new StringBuilder();

            if (config.TaskConfig.IosCompatible)
            {
                foreach (string s in input)
                {
                    toByte = Encoding.UTF8.GetBytes(s);
                    encoded = Convert.ToBase64String(toByte);
                    result.AppendLine(encoded);
                }
            }
            else
            {
                toByte = Encoding.UTF8.GetBytes(string.Join("", input));
                encoded = Convert.ToBase64String(toByte);
                result.AppendLine(encoded);
            }

            return result.ToString();
        }


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
            // Refactor this to use IServer and IConfiguration
            List<string> result = new();
            try
            {
                List<InboundModel> inbounds = Database.FetchDBFromServer(ClientServer).GetInbounds(config.ClientServer.PanelType);

                if (config.TaskConfig.IPsection)
                {
                    List<string> IPList = await config.TaskConfig.IPFilePath.ToIPList();
                    List<List<InboundModel>> PermutatedInbounds = Inbound.PermutateIPS(inbounds, IPList);

                    if (config.TaskConfig.SeperatePermutations)
                    {
                        foreach (List<InboundModel> permutated in PermutatedInbounds)
                        {
                            List<string> links = permutated.Select(inbound =>
                            {
                                if (inbound.Protocol == "vmess")
                                {
                                    return Inbound.VmessEncoder(inbound);
                                }
                                else if (inbound.Protocol == "vless")
                                {
                                    return Inbound.VlessGenerator(inbound);
                                }
                                else
                                {
                                    return new List<string>();
                                }
                            }).SelectMany(x => x).ToList();

                            string encodedLinks = ConvertToBase64(links, config);
                            await IO.WriteToFileAsync(encodedLinks, config);
                        }

                        inbounds = PermutatedInbounds.SelectMany(x => x).ToList();
                    }
                }

                foreach (InboundModel inbound in inbounds)
                {

                    if (inbound.Protocol == "vmess")
                    {
                        result.AddRange(Inbound.VmessEncoder(inbound));
                    }
                    else if (inbound.Protocol == "vless")
                    {
                        result.AddRange(Inbound.VlessGenerator(inbound));
                    }
                }

                string EncodedLinks = ConvertToBase64(result, config);
                await IO.WriteToFileAsync(EncodedLinks, config);

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}