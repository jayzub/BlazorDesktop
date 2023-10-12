using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebviewAppShared.Data
{
    public class TD
    {
        public int TD1 { get; set; }
        [Required(ErrorMessage = "Machine is required.")]
        public string TD2 { get; set; }
        [Required(ErrorMessage = "Hours is required.")]
        public string TD3 { get; set; }
        [Required(ErrorMessage = "Operator is required.")]
        public string TD4 { get; set; }
      
        public string TD5 { get; set; }
        
        [Required(ErrorMessage = "Sensor is required.")]
        public string TD6 { get; set; }
        public DateTime TD7 { get; set; }
        public string TD8 { get; set; }

    }
}
