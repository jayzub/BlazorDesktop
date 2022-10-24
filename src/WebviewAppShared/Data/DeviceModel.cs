using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebviewAppShared.Data
{
    internal class DeviceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Serial_number { get; set; }

        public string Status { get; set; }

        public DateTime Last_tested { get; set; }
    }
}
