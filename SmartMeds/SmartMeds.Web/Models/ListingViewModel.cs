namespace SmartMeds.Web.Models
{
    public class ListingViewModel
    {
        public Guid Id { get; set; }
        public Guid MedicineId { get; set; }
        public string MedicineName { get; set; } = null!; 
        public decimal Price { get; set; }
    }
}