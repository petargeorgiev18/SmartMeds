using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartMeds.Data.Configurations;
using SmartMeds.Data.Entities;

namespace SmartMeds.Data
{
    public class SmartMedsDbContext : IdentityDbContext<SmartMedsUser, IdentityRole<long>, long>
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

            modelBuilder.Entity<SmartMedsUser>()
                .HasOne(u => u.Hospital)
                .WithMany()
                .HasForeignKey(u => u.HospitalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfiguration(new MedicineConfiguration());
        }
    }
}
