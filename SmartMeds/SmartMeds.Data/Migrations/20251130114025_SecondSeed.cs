using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartMeds.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "ExpirationDate", "ExternalMedicineId", "Name", "Quantity" },
                values: new object[,]
                {
                    { 4L, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "MED-CET-010", "Cetirizine 10mg", 150 },
                    { 5L, new DateTime(2025, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "MED-ASP-100", "Aspirin 100mg", 200 },
                    { 6L, new DateTime(2027, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MED-OME-020", "Omeprazole 20mg", 95 },
                    { 7L, new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "MED-MET-500", "Metformin 500mg", 180 },
                    { 8L, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "MED-LIS-010", "Lisinopril 10mg", 70 },
                    { 9L, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "MED-AZI-500", "Azithromycin 500mg", 35 },
                    { 10L, new DateTime(2026, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MED-PRED-005", "Prednisolone 5mg", 60 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 10L);
        }
    }
}
