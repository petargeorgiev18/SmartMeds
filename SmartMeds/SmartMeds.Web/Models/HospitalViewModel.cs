namespace SmartMeds.Web.Models
{
    public class HospitalViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int SentRequestsCount { get; set; }
        public int ReceivedRequestsCount { get; set; }
    }
}