using SmartMeds.Data.Enums;

namespace SmartMeds.Web.Models
{
    public class RequestViewModel
    {
        public long Id { get; set; }
        public long FromHospitalId { get; set; }
        public string FromHospitalName { get; set; } = null!;
        public long ToHospitalId { get; set; }
        public string ToHospitalName { get; set; } = null!;
        public string MedicineName { get; set; } = null!;
        public RequestStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}