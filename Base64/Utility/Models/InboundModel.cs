using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool Enable { get; set; }
        public int ExpiryTime { get; set; }
        public string Listen { get; set; }
        public int Port { get; set; }
        public string Protocol { get; set; }
        public string Settings { get; set; }
        public string StreamSettings { get; set; }
        public string Tag { get; set; }
        public string Sniffing { get; set; }
    }
}
