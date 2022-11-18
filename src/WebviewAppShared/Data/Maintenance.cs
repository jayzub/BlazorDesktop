using Radzen.Blazor.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebviewAppShared.Data
{
    public class Maintenance
    {
        public string MachineSerialNumber { get; set; }
        public string Axis { get; set; }
        public string Component { get; set; }
        public string Task { get; set; }
        public string Note { get; set; }
        public int TestId { get; set; }
    }
}
