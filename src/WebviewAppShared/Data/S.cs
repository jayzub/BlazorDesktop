using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebviewAppShared.Data
{
    public class S
    {
        public int S1 { get; set; }
        public string S2 { get; set; } //name cDAQ1Mod1
        public string S3 { get; set; } //DAQ Model
        public long S4 { get; set; } //DAQ Serial 
        [Required(ErrorMessage = "Accelerometer value required.")]
        public string S5 { get; set; } //Accelerometer
        public double S6 { get; set; } = 100; // Accel X Sens 
        public double S7 { get; set; } = 100.2;// Accel Y Sens
        public double S8 { get; set; } = 100.4;// Accel Z Sens
        public int S9 { get; set; } = 12800;// Sensor sampling frequnecy

    }
}
