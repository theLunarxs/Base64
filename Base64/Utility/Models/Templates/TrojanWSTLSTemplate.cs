using static Base64.Utility.Models.Templates.VlessWSTLSTemplate;

namespace Base64.Utility.Models.Templates
{
    internal class TrojanWSTLSTemplate
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
            public InboundProtocolSettings Settings { get; set; }
            public InboundSniffingSettings Sniffing { get; set; }
        }

        public class InboundProtocolSettings
        {
            public string Auth { get; set; }
            public bool Udp { get; set; }
            public string Ip { get; set; }
        }

        public class InboundSniffingSettings
        {
            public bool Enabled { get; set; }
            public string[] DestOverride { get; set; }
        }

        public class Outbound
        {
            public string Tag { get; set; }
            public string Protocol { get; set; }
            public OutboundProtocolSettings Settings { get; set; }
            public OutboundStreamSettings StreamSettings { get; set; }
            public OutboundMuxSettings Mux { get; set; }
        }

        public class OutboundProtocolSettings
        {
            public List<OutboundServerSettings> Vnext { get; set; }
        }

        public class OutboundServerSettings
        {
            public string Address { get; set; }
            public int Port { get; set; }
            public List<OutboundUserSettings> Users { get; set; }
        }

        public class OutboundUserSettings
        {
            public string Id { get; set; }
            public string Encryption { get; set; }
        }

        public class OutboundStreamSettings
        {
            public string Network { get; set; }
            public string Security { get; set; }
            public OutboundTlsSettings TlsSettings { get; set; }
            public OutboundWsSettings WsSettings { get; set; }
            public OutboundGrpcSettings GrpcSettings { get; set; }
        }

        public class OutboundTlsSettings
        {
            public bool AllowInsecure { get; set; }
            public string ServerName { get; set; }
            public string[] Alpn { get; set; }
            public string Fingerprint { get; set; }
        }

        public class OutboundWsSettings
        {
            public string Path { get; set; }
            public Headers Headers { get; set; }
        }

        public class Headers
        {
            public string Host { get; set; }
        }

        public class OutboundGrpcSettings
        {
            public string ServiceName { get; set; }
            public bool MultiMode { get; set; }
        }

        public class OutboundMuxSettings
        {
            public bool Enabled { get; set; }
            public int Concurrency { get; set; }
        }
    }
}
