using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMeds.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMeds.Data.Configurations
{
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasData(
                new Medicine
                {
                    Id = 1,
                    Name = "Paracetamol 500mg",
                    ExternalMedicineId = "MED-PARA-500",
                    Quantity = 120,
                    ExpirationDate = new DateTime(2026, 1, 1)
                },
                new Medicine
                {
                    Id = 2,
                    Name = "Ibuprofen 200mg",
                    ExternalMedicineId = "MED-IBU-200",
                    Quantity = 80,
                    ExpirationDate = new DateTime(2025, 5, 12)
                },
                new Medicine
                {
                    Id = 3,
                    Name = "Amoxicillin 250mg",
                    ExternalMedicineId = "MED-AMOX-250",
                    Quantity = 40,
                    ExpirationDate = new DateTime(2024, 12, 31)
                }
            );
        }
    }
}
