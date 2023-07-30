using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebviewAppShared.Data
{
    public class MC
    {
        public string MC1 { get; set; }
        public string MC2 { get; set; }
        public string MC3 { get; set; }
        public string MC4 { get; set; }

        // used to count
        public int count { get; set; }
        //Serial Number
        public string M1 { get; set; }
        public string M2 { get; set; }

        // List to hold dataPlotHolder instances for each batch
        public List<dataPlotHolder> DataPlotHolders { get; set; } = new List<dataPlotHolder>();

        public class dataPlotHolder
        {
            public string[] Count { get; set; }
            public List<int> DataPlotPointerValue { get; set; } = new List<int>();
        }


    }
}
