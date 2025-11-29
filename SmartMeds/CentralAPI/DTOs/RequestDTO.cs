using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralAPI.DTOs
{
    internal class RequestDTO
    {
        public int id { get; set; }
        public HospitalDTO from { get; set; }
        public HospitalDTO to { get; set; }
        public int amount { get; set; }
        public int medicineFK { get; set; }
        public string expirationDate { get; set; }
        public string postedAt { get; set; }
        public string status { get; set; }
    }
}
