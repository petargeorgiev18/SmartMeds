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
        public Guid Id { get; set; }
        [ForeignKey(nameof(FromHospital))]    
        public Guid FromHospitalId { get; set; }
        [ForeignKey(nameof(ToHospital))]
        public Guid ToHospitalId { get; set; }
        public Hospital FromHospital { get; set; } = null!;
        public Hospital ToHospital { get; set; } = null!;
        public string ExternalMedicineId { get; set; }
        public int Quantity { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
    }
}
