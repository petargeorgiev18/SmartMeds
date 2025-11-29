using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartMeds.Data.Entities;

namespace SmartMeds.Data
{
    public class SmartMedsDbContext : IdentityDbContext<SmartMedsUser, IdentityRole<Guid>, Guid>
    {
        public SmartMedsDbContext(DbContextOptions<SmartMedsDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Listing> Listings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Request>()
                .HasOne(r => r.FromHospital)
                .WithMany(h => h.SentRequests)
                .HasForeignKey(r => r.FromHospitalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Request>()
                .HasOne(r => r.ToHospital)
                .WithMany(h => h.ReceivedRequests)
                .HasForeignKey(r => r.ToHospitalId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
