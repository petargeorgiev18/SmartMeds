namespace SmartMeds.Web.Models
{
    public class ListingViewModel
    {
        public long Id { get; set; }
        public long MedicineId { get; set; }
        public string MedicineName { get; set; } = null!; 
        public double Price { get; set; }
    }
}