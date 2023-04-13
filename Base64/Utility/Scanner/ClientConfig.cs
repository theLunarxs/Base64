using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Base64.Utility.Models.Templates;
namespace Base64.Utility.Scanner
{
    public class ClientConfig
    {
        public ClientConfig(ConfigType Type, int Port, string UUID, string Host, string Path, string SNI, string IP)
        {
            if (!File.Exists($@"/ConfigTemplates/{Type}Template.json"))
            {
                throw new FileNotFoundException("File not Found");
            }

            var template = File.Open(@$"/ConfigTemplates/{Type}Template.Json", FileMode.Open);

            if (Type == ConfigType.VmessWSTLS)
            {
                var JObject = JsonSerializer.Deserialize<VmessWSTLSTemplate.Configuration>(JsonDocument.Parse(template))!;

                JObject.Outbounds[0].Settings.Vnext[0].Port = Port;

                // TODO: reConsider this next line based on Users
                JObject.Outbounds[0].Settings.Vnext[0].Users[0].Id = UUID;
                JObject.Outbounds[0].StreamSettings.WsSettings.Headers.host = Host;
                JObject.Outbounds[0].StreamSettings.WsSettings.Path = Path;
                JObject.Outbounds[0].StreamSettings.TlsSettings.ServerName = SNI;

                JObject.Inbounds[0].Port = GenerateRandomPortFromGivenIP(IP).ToString();
                JObject.Outbounds[0].Settings.Vnext[0].Address = IP;
            }

            else if (Type == ConfigType.VlessGRPCTLS)
            {
                var JObject = JsonSerializer.Deserialize<VlessgrpcTLSTemplate>(JsonDocument.Parse(template))!;

            }
            else if (Type == ConfigType.TrojanWSTLS)
            {
                var JObject = JsonSerializer.Deserialize<TrojanWSTLSTemplate>(JsonDocument.Parse(template))!;


            }
        }

        public enum ConfigType
        {
            VmessWSTLS,
            VlessGRPCTLS,
            TrojanWSTLS
        }

        private static int GenerateRandomPortFromGivenIP(string IP)
        {
            int sum = Int32.Parse(
                IP.Split(".").Aggregate((current, next) =>
                          (Int32.Parse(current) + Int32.Parse(next)).ToString()));

            return 3000 + sum;
        }
    }
}
