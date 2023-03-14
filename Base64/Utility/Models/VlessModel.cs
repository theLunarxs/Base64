using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Base64.Utility.Models
{
    public class VlessModel
    {
        public string UUID { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public string type { get; set; }
        public string security { get; set; }
        public string path { get; set; }
        public string host { get; set; }
        public string SNI { get; set; }
        public string Remark { get; set; }
    }

}
