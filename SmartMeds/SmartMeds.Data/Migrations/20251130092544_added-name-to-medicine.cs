using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMeds.Data.Migrations
{
    /// <inheritdoc />
    public partial class addednametomedicine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Requests");
        }
    }
}
