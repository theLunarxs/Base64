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
        public string TemplateConfigPath;

        public ClientConfig(ConfigType Type, int Port, string UUID, string Host, string Path, string SNI, string IP, NetworkType network = NetworkType.WSTLS)
        {
            if (!File.Exists($@"/ConfigTemplates/{Type}Template.json"))
            {
                throw new FileNotFoundException("File not Found");
            }

            var template = File.Open(@$"/ConfigTemplates/{Type}Template.Json", FileMode.Open);
            TemplateConfigPath = $@"/ConfigTemplates/UserConfigs/{Type}.json";
            if (Type == ConfigType.Vmess)
            {
                var JObject = JsonSerializer.Deserialize<VmessWSTLSTemplate.Configuration>(JsonDocument.Parse(template))!;


                JObject.Outbounds[0].Settings.Vnext[0].Port = Port;
                // TODO: reConsider this next line based on Users
                JObject.Outbounds[0].Settings.Vnext[0].Users[0].Id = UUID;
                JObject.Outbounds[0].StreamSettings.WsSettings.Headers.Host = Host;
                JObject.Outbounds[0].StreamSettings.WsSettings.Path = Path;
                JObject.Outbounds[0].StreamSettings.TlsSettings.ServerName = SNI;

                JObject.Inbounds[0].Port = GenerateRandomPortFromGivenIP(IP).ToString();
                JObject.Outbounds[0].Settings.Vnext[0].Address = IP;

                var result = JsonSerializer.Serialize(JObject);
                File.WriteAllText(TemplateConfigPath, result);
                
            }

            else if (Type == ConfigType.Vless)
            {
                if (network == NetworkType.GRPCTLS)
                {
                    var JObject = JsonSerializer.Deserialize<VlessGRPCTLSTemplate.Configuration>(JsonDocument.Parse(template))!;

                    JObject.Outbounds[0].Settings.Vnext[0].Port = Port;
                    JObject.Outbounds[0].Settings.Vnext[0].Users[0].Id = UUID;
                    JObject.Outbounds[0].StreamSettings.TlsSettings.ServerName = SNI;

                    JObject.Inbounds[0].Port = GenerateRandomPortFromGivenIP(IP).ToString();
                    JObject.Outbounds[0].Settings.Vnext[0].Address = IP;

                    var result = JsonSerializer.Serialize(JObject);
                    File.WriteAllText(TemplateConfigPath, result);
                }

                else if (network == NetworkType.WSTLS)
                {
                    var JObject = JsonSerializer.Deserialize<VlessWSTLSTemplate.Configuration>(JsonDocument.Parse(template))!;

                    JObject.Outbounds[0].Settings.Vnext[0].Port = Port;
                    // TODO: reConsider this next line based on Users
                    JObject.Outbounds[0].Settings.Vnext[0].Users[0].Id = UUID;
                    JObject.Outbounds[0].StreamSettings.WsSettings.Headers.Host = Host;
                    JObject.Outbounds[0].StreamSettings.WsSettings.Path = Path;
                    JObject.Outbounds[0].StreamSettings.TlsSettings.ServerName = SNI;

                    JObject.Inbounds[0].Port = GenerateRandomPortFromGivenIP(IP).ToString();
                    JObject.Outbounds[0].Settings.Vnext[0].Address = IP;

                    var result = JsonSerializer.Serialize(JObject);
                    File.WriteAllText(TemplateConfigPath, result);
                }
            }
            else if (Type == ConfigType.Trojan)
            {
                var JObject = JsonSerializer.Deserialize<TrojanWSTLSTemplate.Configuration>(JsonDocument.Parse(template))!;

                JObject.Outbounds[0].Settings.Vnext[0].Port = Port;
                // TODO: reConsider this next line based on Users
                JObject.Outbounds[0].Settings.Vnext[0].Users[0].Id = UUID;
                JObject.Outbounds[0].StreamSettings.WsSettings.Headers.Host = Host;
                JObject.Outbounds[0].StreamSettings.WsSettings.Path = Path;
                JObject.Outbounds[0].StreamSettings.TlsSettings.ServerName = SNI;

                JObject.Inbounds[0].Port = GenerateRandomPortFromGivenIP(IP).ToString();
                JObject.Outbounds[0].Settings.Vnext[0].Address = IP;

                var result = JsonSerializer.Serialize(JObject);
                File.WriteAllText(TemplateConfigPath, result);
            }
        }
        public enum ConfigType
        {
            Vmess,
            Vless,
            Trojan,
        }
        public enum NetworkType
        {
            GRPCTLS,
            WSTLS
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
