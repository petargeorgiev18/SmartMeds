using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralAPI.DTOs
{
    internal class HospitalDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string address { get; set; }
    }
}
