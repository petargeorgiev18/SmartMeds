using Microsoft.AspNetCore.Identity;

namespace SmartMeds.Data.Entities
{
    public class SmartMedsUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = null!;
        public Guid? HospitalId { get; set; }
        public Hospital? Hospital { get; set; }
    }
}