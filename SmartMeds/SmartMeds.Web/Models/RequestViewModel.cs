using SmartMeds.Data.Enums;

namespace SmartMeds.Web.Models
{
    public class RequestViewModel
    {
        public Guid Id { get; set; }
        public Guid FromHospitalId { get; set; }
        public string FromHospitalName { get; set; } = null!;
        public Guid ToHospitalId { get; set; }
        public string ToHospitalName { get; set; } = null!;
        public string MedicineName { get; set; } = null!;
        public RequestStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}