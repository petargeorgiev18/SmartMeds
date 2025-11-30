using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMeds.Data.Entities
{
    public class Listing
    {
        public long Id { get; set; }
        [ForeignKey(nameof(Medicine))]
        public long MedicineId { get; set; }
        public Medicine? Medicine { get; set; } = null;
        public double Price { get; set; }
        public int Quantity { get; set; }

    }
}
