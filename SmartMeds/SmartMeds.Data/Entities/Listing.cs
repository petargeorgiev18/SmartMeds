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
        public Guid Id { get; set; }
        [ForeignKey(nameof(Medicine))]
        public Guid MedicineId { get; set; }
        public Medicine? Medicine { get; set; } = null;
        public decimal Price { get; set; }

    }
}
