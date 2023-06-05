namespace Base64.Utility.Models
{
    public class InboundModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Up { get; set; }
        public int Down { get; set; }
        public int Total { get; set; }
        public string Remark { get; set; }
        public int Enable { get; set; }
        public int ExpiryTime { get; set; }
        public string? Listen { get; set; }
        public int Port { get; set; }
        public string Protocol { get; set; }
        public Settings Settings { get; set; }
        public StreamSettings StreamSettings { get; set; }
        public string Tag { get; set; }
        public Sniffing Sniffing { get; set; }
        public int autoreset { get; set; }
        public int IPalert { get; set; }
        public int IPLimit { get; set; }
    }
    public class Settings
    {
        public List<Client> clients { get; set; }
        public bool disableInsecureEncryption { get; set; }

        public class Client
        {
            public string id { get; set; }
            public int alterId { get; set; }
            public string email { get; set; }
            public int limitIp { get; set; }
            public int totalGB { get; set; }
            public string expiryTime { get; set; }
            public string password { get; set; }
            public string flow { get; set; }
        }
    }
    public class StreamSettings
    {
        public string network { get; set; }
        public string security { get; set; }
        public TlsSettings tlsSettings { get; set; }
        public WsSettings wsSettings { get; set; }

        public class TlsSettings
        {
            public string serverName { get; set; }
            public string minVersion { get; set; }
            public string maxVersion { get; set; }
            public string cipherSuites { get; set; }
            public List<Certificate> certificates { get; set; }
            public List<string> alpn { get; set; }

            public class Certificate
            {
                public string certificateFile { get; set; }
                public string keyFile { get; set; }
            }
        }

        public class WsSettings
        {
            public bool acceptProxyProtocol { get; set; }
            public string path { get; set; }
            public Headers headers { get; set; }
        }
        public class Headers
        {
            public string Host { get; set; }
        }
    }
    public class Sniffing
    {
        public bool enabled { get; set; }
        public List<string> destOverride { get; set; }
    }


}
