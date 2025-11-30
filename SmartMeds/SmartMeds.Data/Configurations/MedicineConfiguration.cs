using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMeds.Data.Entities;

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
                },
                new Medicine
                {
                    Id = 4,
                    Name = "Cetirizine 10mg",
                    ExternalMedicineId = "MED-CET-010",
                    Quantity = 150,
                    ExpirationDate = new DateTime(2026, 3, 15)
                },
                new Medicine
                {
                    Id = 5,
                    Name = "Aspirin 100mg",
                    ExternalMedicineId = "MED-ASP-100",
                    Quantity = 200,
                    ExpirationDate = new DateTime(2025, 7, 9)
                },
                new Medicine
                {
                    Id = 6,
                    Name = "Omeprazole 20mg",
                    ExternalMedicineId = "MED-OME-020",
                    Quantity = 95,
                    ExpirationDate = new DateTime(2027, 2, 1)
                },
                new Medicine
                {
                    Id = 7,
                    Name = "Metformin 500mg",
                    ExternalMedicineId = "MED-MET-500",
                    Quantity = 180,
                    ExpirationDate = new DateTime(2026, 8, 22)
                },
                new Medicine
                {
                    Id = 8,
                    Name = "Lisinopril 10mg",
                    ExternalMedicineId = "MED-LIS-010",
                    Quantity = 70,
                    ExpirationDate = new DateTime(2025, 10, 14)
                },
                new Medicine
                {
                    Id = 9,
                    Name = "Azithromycin 500mg",
                    ExternalMedicineId = "MED-AZI-500",
                    Quantity = 35,
                    ExpirationDate = new DateTime(2025, 4, 3)
                },
                new Medicine
                {
                    Id = 10,
                    Name = "Prednisolone 5mg",
                    ExternalMedicineId = "MED-PRED-005",
                    Quantity = 60,
                    ExpirationDate = new DateTime(2026, 12, 12)
                }
            );
        }
    }
}
