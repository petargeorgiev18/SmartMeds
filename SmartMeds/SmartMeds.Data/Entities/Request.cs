using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartMeds.Data.Enums;

namespace SmartMeds.Data.Entities
{
    public class Request
    {
        public long Id { get; set; }
        [ForeignKey(nameof(FromHospital))]    
        public long FromHospitalId { get; set; }
        [ForeignKey(nameof(ToHospital))]
        public long ToHospitalId { get; set; }
        public Hospital FromHospital { get; set; } = null!;
        public Hospital ToHospital { get; set; } = null!;
        public long ExternalMedicineId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public DateTime ExpirationDate { get; set; }
        public DateTime PostedAt { get; set; }
    }
}
