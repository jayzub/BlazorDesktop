using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebviewAppShared.Data
{
    public class Device
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public string LastTested { get; set; }
    }
}
