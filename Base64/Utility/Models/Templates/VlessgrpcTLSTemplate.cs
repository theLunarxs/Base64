using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64.Utility.Models.Templates
{
    internal class VlessGRPCTLSTemplate
    {
        public class Configuration
        {
            public List<Inbound> Inbounds { get; set; }
            public List<Outbound> Outbounds { get; set; }
            public Dictionary<string, object> Other { get; set; }
        }

        public class Inbound
        {
            public string Port { get; set; }
            public string Listen { get; set; }
            public string Tag { get; set; }
            public string Protocol { get; set; }
            public InboundSettings Settings { get; set; }
            public InboundSniffing Sniffing { get; set; }
        }

        public class InboundSettings
        {
            public string Auth { get; set; }
            public bool Udp { get; set; }
            public string Ip { get; set; }
        }

        public class InboundSniffing
        {
            public bool Enabled { get; set; }
            public List<string> DestOverride { get; set; }
        }

        public class Outbound
        {
            public string Protocol { get; set; }
            public OutboundSettings Settings { get; set; }
            public OutboundStreamSettings StreamSettings { get; set; }
        }

        public class OutboundSettings
        {
            public List<OutboundServer> Vnext { get; set; }
        }

        public class OutboundServer
        {
            public string Address { get; set; }
            public int Port { get; set; }
            public List<OutboundUser> Users { get; set; }
        }

        public class OutboundUser
        {
            public string Id { get; set; }
            public string Encryption { get; set; }
        }

        public class OutboundStreamSettings
        {
            public string Network { get; set; }
            public string Security { get; set; }
            public OutboundTlsSettings TlsSettings { get; set; }
            public OutboundGrpcSettings GrpcSettings { get; set; }
        }

        public class OutboundTlsSettings
        {
            public bool AllowInsecure { get; set; }
            public string ServerName { get; set; }
            public List<string> Alpn { get; set; }
            public string Fingerprint { get; set; }
        }

        public class OutboundGrpcSettings
        {
            public string ServiceName { get; set; }
            public bool MultiMode { get; set; }
        }

    }
}
