using SmartMeds.Data.Enums;

namespace SmartMeds.Web.Models
{
    public class MedicineViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ExternalMedicineId { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public StockStatus Status { get; set; }
    }
}