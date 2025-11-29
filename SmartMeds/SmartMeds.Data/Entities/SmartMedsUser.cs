using Microsoft.AspNetCore.Identity;

namespace SmartMeds.Data.Entities
{
    public class SmartMedsUser : IdentityUser<long>
    {
        public string FullName { get; set; } = null!;
        public long? HospitalId { get; set; }
        public Hospital? Hospital { get; set; }
    }
}