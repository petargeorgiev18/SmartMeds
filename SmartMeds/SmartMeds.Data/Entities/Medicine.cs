using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SmartMeds.Data.Enums;

namespace SmartMeds.Data.Entities
{
    public class Medicine
    {
        public Guid Id { get; set; }    
        public string ExternalMedicineId { get; set; }
        public int Quantity { get;set; }
        public DateTime ExpirationDate { get; set; }
        public StockStatus Status
        {
            get
            {
                var today = DateTime.Today;

                if (ExpirationDate < today)
                {
                    return StockStatus.Expired;
                }

                var daysLeft = (ExpirationDate - today).TotalDays;

                if (daysLeft <= 30)
                {
                    return StockStatus.CloseToExpiration;
                }

                return StockStatus.Good;
            }
        }
    }
}
