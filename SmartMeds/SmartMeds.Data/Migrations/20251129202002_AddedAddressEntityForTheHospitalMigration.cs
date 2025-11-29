using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMeds.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedAddressEntityForTheHospitalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Hospitals");
        }
    }
}
