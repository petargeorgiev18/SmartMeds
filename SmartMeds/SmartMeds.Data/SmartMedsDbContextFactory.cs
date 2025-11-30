using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SmartMeds.Data
{
    public class SmartMedsDbContextFactory : IDesignTimeDbContextFactory<SmartMedsDbContext>
    {
        public SmartMedsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SmartMedsDbContext>();

            // Use the same connection string from appsettings.json
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=SmartMeds;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

            return new SmartMedsDbContext(optionsBuilder.Options);
        }
    }
}
