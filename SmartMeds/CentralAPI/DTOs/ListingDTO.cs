using SmartMeds.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralAPI.DTOs
{
    internal class ListingDTO
    {
        public long id { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string expirationDate { get; set; }
        public long medicineFK { get; set; }
        public HospitalDTO hospital { get; set; }

        internal Listing ToListing()
        {
            Listing l = new Listing();
            l.Id = id;
            l.Price = price;
            l.MedicineId = medicineFK;
            return l;
        }
    }
}
