using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebviewAppShared.Data
{
    public class Test
    {
        public int TestId { get; set; }
        public string MachineSerialNumber { get; set; }
        public string Hours { get; set; }
        public string Operator { get; set; }
        public string Mode { get; set; }
        public string Sensor { get; set; }
        public DateTime Date { get; set; }
        public string Health { get; set; }
    }
}