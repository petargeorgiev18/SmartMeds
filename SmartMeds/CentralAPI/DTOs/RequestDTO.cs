using SmartMeds.Data.Entities;
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
        public long medicineFK { get; set; }
        public DateTime expirationDate { get; set; }
        public DateTime postedAt { get; set; }
        public string status { get; set; }

        internal Request toRequest()
        {
            Request res = new Request();
            res.Id = id;
            res.FromHospitalId = from.id;
            res.ToHospitalId = to.id;
            res.Quantity = amount;
            res.ExternalMedicineId = medicineFK;
            switch(status)
            {
                case "PENDING": res.Status = SmartMeds.Data.Enums.RequestStatus.Pending; break;
                case "DECLINED": res.Status = SmartMeds.Data.Enums.RequestStatus.Declined; break;
                case "ACCEPTED": res.Status = SmartMeds.Data.Enums.RequestStatus.Accepted; break;
                case "COMPLEATED": res.Status = SmartMeds.Data.Enums.RequestStatus.Completed; break;
            }
            res.ExpirationDate = expirationDate;
            res.PostedAt = postedAt;
            return res;
        }

    }
}
