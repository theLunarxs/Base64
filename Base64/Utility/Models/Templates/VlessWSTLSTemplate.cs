namespace Base64.Utility.Models.Templates
{
    internal class VlessWSTLSTemplate
    {
        public class Configuration
        {
            public List<Inbound> Inbounds { get; set; }
            public List<Outbound> Outbounds { get; set; }
            public Other Other { get; set; }
        }

        public class Inbound
        {
            public string Port { get; set; }
            public string Listen { get; set; }
            public string Tag { get; set; }
            public string Protocol { get; set; }
            public InboundSettings Settings { get; set; }
            public Sniffing Sniffing { get; set; }
        }

        public class InboundSettings
        {
            public string Auth { get; set; }
            public bool Udp { get; set; }
            public string Ip { get; set; }
        }

        public class Sniffing
        {
            public bool Enabled { get; set; }
            public List<string> DestOverride { get; set; }
        }

        public class Outbound
        {
            public string Tag { get; set; }
            public string Protocol { get; set; }
            public OutboundSettings Settings { get; set; }
            public StreamSettings StreamSettings { get; set; }
        }

        public class OutboundSettings
        {
            public List<Vnext> Vnext { get; set; }
        }

        public class Vnext
        {
            public string Address { get; set; }
            public int Port { get; set; }
            public List<User> Users { get; set; }
        }

        public class User
        {
            public string Id { get; set; }
            public string Encryption { get; set; }
        }

        public class StreamSettings
        {
            public string Network { get; set; }
            public string Security { get; set; }
            public TlsSettings TlsSettings { get; set; }
            public WsSettings WsSettings { get; set; }
        }

        public class TlsSettings
        {
            public bool AllowInsecure { get; set; }
            public string ServerName { get; set; }
            public List<string> Alpn { get; set; }
            public string Fingerprint { get; set; }
        }

        public class WsSettings
        {
            public string Path { get; set; }
            public Headers Headers { get; set; }
        }

        public class Headers
        {
            public string Host { get; set; }
        }

        public class Other
        {

        }

    }
}
