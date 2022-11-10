using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class DataPlot
    {
        public double Timestamp { get; set; }
        public double xAxis { get; set; }
        public double yAxis { get; set; }
        public double zAxis { get; set; }
        public DataPlot(double t, double x, double y, double z)
        {
            Timestamp = Timestamp;
            xAxis = x;
            yAxis = y;
            zAxis = z;
        }
    }
}
