using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64.Utility.Models
{
    public class VmessBase64Model
    {
        public string v { get; set; }
        public string ps { get; set; }
        public string add { get; set; }
        public int port { get; set; }
        public string id { get; set; }
        public int aid { get; set; }
        public string scy { get; set; }
        public string net { get; set; }
        public string type { get; set; }
        public string host { get; set; }
        public string path { get; set; }
        public string tls { get; set; }
        public string sni { get; set; }
        public string alpn { get; set; }
    }
}
