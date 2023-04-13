using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64.Utility.Models
{
    public class TrojanModel : VlessModel
    {
        public string serviceName { get; set; }
        public string alpn { get; set; }
        public string fp { get; set; }
        public string mode { get; set; }
    }
}
