using Microsoft.EntityFrameworkCore;

namespace SmartMeds.Data
{
    public class SmartMedsDbContext : DbContext
    {
        public SmartMedsDbContext(DbContextOptions<SmartMedsDbContext> options)
            : base(options)
        {
        }
    }
}
