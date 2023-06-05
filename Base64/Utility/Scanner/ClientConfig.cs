using Base64.Utility.Models.Templates;
using System.Text.Json;
using static Base64.Utility.Scanner.ClientConfig;
using static Base64.Utility.Scanner.Configurations;

namespace Base64.Utility.Scanner
{
    /*
     Summery
    in this class we first read the corresponding JSON template from disk, then we modify object values based on
        the data given to the constructor, and then we save the new Object to the disk so that the Engine could read it.
     */
    public class ClientConfig
    {
        public readonly string ClientConfigPath;
        public readonly ConfigType Ctype;
        public readonly NetworkType Ntype;
        public string currentIP;
        public ClientConfig(ClientConfiguration Config)
        {
            if (!File.Exists($@"/ConfigTemplates/{Config.ConfigType}Template.json"))
            {
                throw new FileNotFoundException("File not Found");
            }

            // Open the template file for reading
            var template = File.Open(@$"/ConfigTemplates/{Config.ConfigType}{Config.NetworkType}Template.Json", FileMode.Open);

            // Define the path for the client configuration file
            ClientConfigPath = $@"/ConfigTemplates/UserConfigs/Client-{Config.ConfigType}{Config.NetworkType}{DateTime.Now.Second}.json";

            if (Config.ConfigType == ConfigType.Vmess)
            {
                string result;
                Ctype = ConfigType.Vmess;
                if (Config.NetworkType == NetworkType.WSTLS)
                {
                    Ntype = NetworkType.WSTLS;
                    // Deserialize the template into a VmessWSTLSTemplate.Configuration object
                    var JObject = JsonSerializer.Deserialize<VmessWSTLSTemplate.Configuration>(JsonDocument.Parse(template))!;

                    // Modify the necessary properties in the configuration object
                    JObject.Outbounds[0].Settings.Vnext[0].Port = Config.Port;
                    JObject.Outbounds[0].Settings.Vnext[0].Users[0].Id = Config.UUID;
                    JObject.Outbounds[0].StreamSettings.WsSettings.Headers.Host = Config.Host;
                    JObject.Outbounds[0].StreamSettings.WsSettings.Path = Config.Path;
                    JObject.Outbounds[0].StreamSettings.TlsSettings.ServerName = Config.SNI;

                    JObject.Inbounds[0].Port = GenerateRandomPortFromGivenIP(Config.IP).ToString();

                    // Serialize the modified configuration object back to JSON
                    result = JsonSerializer.Serialize(JObject);
                }
                else
                {
                    Ntype = NetworkType.GRPCTLS;
                    // Deserialize the template into a VmessGRPCTLSTemplate.Configuration object
                    var JObject = JsonSerializer.Deserialize<VmessGRPCTLSTemplate.Configuration>(JsonDocument.Parse(template))!;

                    // Modify the necessary properties in the configuration object
                    JObject.Outbounds[0].Settings.Vnext[0].Port = Config.Port;
                    JObject.Outbounds[0].Settings.Vnext[0].Users[0].Id = Config.UUID;
                    JObject.Outbounds[0].StreamSettings.TlsSettings.ServerName = Config.SNI;

                    JObject.Inbounds[0].Port = GenerateRandomPortFromGivenIP(Config.IP).ToString();

                    // Serialize the modified configuration object back to JSON
                    result = JsonSerializer.Serialize(JObject);
                }

                // Write the resulting JSON to the client configuration file
                File.WriteAllText(ClientConfigPath, result);
            }
            else if (Config.ConfigType == ConfigType.Vless)
            {
                Ctype = ConfigType.Vless;
                if (Config.NetworkType == NetworkType.GRPCTLS)
                {
                    Ntype = NetworkType.GRPCTLS;
                    // Deserialize the template into a VlessGRPCTLSTemplate.Configuration object
                    var JObject = JsonSerializer.Deserialize<VlessGRPCTLSTemplate.Configuration>(JsonDocument.Parse(template))!;

                    // Modify the necessary properties in the configuration object
                    JObject.Outbounds[0].Settings.Vnext[0].Port = Config.Port;
                    JObject.Outbounds[0].Settings.Vnext[0].Users[0].Id = Config.UUID;
                    JObject.Outbounds[0].StreamSettings.TlsSettings.ServerName = Config.SNI;

                    JObject.Inbounds[0].Port = GenerateRandomPortFromGivenIP(Config.IP).ToString();

                    // Serialize the modified configuration object back to JSON
                    var result = JsonSerializer.Serialize(JObject);
                    File.WriteAllText(ClientConfigPath, result);
                }
                else if (Config.NetworkType == NetworkType.WSTLS)
                {
                    Ntype = NetworkType.WSTLS;
                    // Deserialize the template into a VlessWSTLSTemplate.Configuration object
                    var JObject = JsonSerializer.Deserialize<VlessWSTLSTemplate.Configuration>(JsonDocument.Parse(template))!;
                    // Modify the necessary properties in the configuration object
                    JObject.Outbounds[0].Settings.Vnext[0].Port = Config.Port;
                    JObject.Outbounds[0].Settings.Vnext[0].Users[0].Id = Config.UUID;
                    JObject.Outbounds[0].StreamSettings.WsSettings.Headers.Host = Config.Host;
                    JObject.Outbounds[0].StreamSettings.WsSettings.Path = Config.Path;
                    JObject.Outbounds[0].StreamSettings.TlsSettings.ServerName = Config.SNI;

                    JObject.Inbounds[0].Port = GenerateRandomPortFromGivenIP(Config.IP).ToString();

                    // Serialize the modified configuration object back to JSON
                    var result = JsonSerializer.Serialize(JObject);
                    File.WriteAllText(ClientConfigPath, result);
                }
            }
            else if (Config.ConfigType == ConfigType.Trojan)
            {
                Ctype = ConfigType.Trojan;
                Ntype = NetworkType.WSTLS;
                // Deserialize the template into a TrojanWSTLSTemplate.Configuration object
                var JObject = JsonSerializer.Deserialize<TrojanWSTLSTemplate.Configuration>(JsonDocument.Parse(template))!;

                // Modify the necessary properties in the configuration object
                JObject.Outbounds[0].Settings.Vnext[0].Port = Config.Port;
                JObject.Outbounds[0].Settings.Vnext[0].Users[0].Id = Config.UUID;
                JObject.Outbounds[0].StreamSettings.WsSettings.Headers.Host = Config.Host;
                JObject.Outbounds[0].StreamSettings.WsSettings.Path = Config.Path;
                JObject.Outbounds[0].StreamSettings.TlsSettings.ServerName = Config.SNI;

                JObject.Inbounds[0].Port = GenerateRandomPortFromGivenIP(Config.IP).ToString();


                // Serialize the modified configuration object back to JSON
                var result = JsonSerializer.Serialize(JObject);

                // Write the resulting JSON to the client configuration file
                File.WriteAllText(ClientConfigPath, result);
            }
        }
        private static int GenerateRandomPortFromGivenIP(string IP)
        {
            int sum = Int32.Parse(
                IP.Split(".").Aggregate((current, next) =>
                          (Int32.Parse(current) + Int32.Parse(next)).ToString()));

            return 3000 + sum;
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
    }
    static class ClientConfigExtensions
    {
        public static void ConvertIP(this ClientConfig clientConfig, string ip)
        {
            if (clientConfig == null || string.IsNullOrEmpty(clientConfig.ClientConfigPath))
            {
                throw new ArgumentNullException(nameof(clientConfig));
            }

            var json = File.ReadAllText(clientConfig.ClientConfigPath);

            if (string.IsNullOrEmpty(json))
            {
                throw new InvalidOperationException("Invalid JSON document.");
            }

            string result;

            if (clientConfig.Ctype == ConfigType.Vless)
            {
                if (clientConfig.Ntype == NetworkType.WSTLS)
                {
                    var configTemplate = JsonSerializer.Deserialize<VlessWSTLSTemplate.Configuration>(json);
                    configTemplate!.Outbounds[0].Settings.Vnext[0].Address = ip;
                    result = JsonSerializer.Serialize(configTemplate);
                }
                else
                {
                    var configTemplate = JsonSerializer.Deserialize<VlessGRPCTLSTemplate.Configuration>(json);
                    configTemplate!.Outbounds[0].Settings.Vnext[0].Address = ip;
                    result = JsonSerializer.Serialize(configTemplate);
                }
            }
            else if (clientConfig.Ctype == ConfigType.Vmess)
            {
                if (clientConfig.Ntype == NetworkType.WSTLS)
                {
                    var configTemplate = JsonSerializer.Deserialize<VmessWSTLSTemplate.Configuration>(json);
                    configTemplate!.Outbounds[0].Settings.Vnext[0].Address = ip;
                    result = JsonSerializer.Serialize(configTemplate);
                }
                else
                {
                    var configTemplate = JsonSerializer.Deserialize<VmessGRPCTLSTemplate.Configuration>(json);
                    configTemplate!.Outbounds[0].Settings.Vnext[0].Address = ip;
                    result = JsonSerializer.Serialize(configTemplate);
                }
            }
            else
            {
                var configTemplate = JsonSerializer.Deserialize<VmessGRPCTLSTemplate.Configuration>(json);
                configTemplate!.Outbounds[0].Settings.Vnext[0].Address = ip;
                result = JsonSerializer.Serialize(configTemplate);
            }
            clientConfig.currentIP = ip;
            File.WriteAllText(clientConfig.ClientConfigPath, result);
        }

    }
}
