using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebviewAppShared.Data
{
    public class MachineComponent
    {
        public string Id { get; set; }
        public string Machine_Name { get; set; }
        public string Axis { get; set; }
        public string Component { get; set; }

        public int count { get; set; }
        public List<string> testRoundDynamic { get; set; }

        public List<string> testCount = new List<string>();

        public List<string> TestCount
        {
            set { testCount = value; }
            get { return testCount; }
        }

    }
}
