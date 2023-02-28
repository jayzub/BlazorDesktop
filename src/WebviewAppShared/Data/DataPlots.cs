using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebviewAppShared.Data
{
    public class DataPlots
    {
        public DateTime TimeStamp { get; set; }
        public double X_Axis { get; set; }
        public double Y_Axis { get; set; }
        public double Z_Axis { get; set; }
        public int TestId { get; set; }
        public int testCount { get; set; }
    }
}
