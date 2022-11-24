using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRegistration.Migrations
{
    /// <inheritdoc />
    public partial class RenameManufacturerIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarManufacturerId",
                table: "CarManufacturers",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CarManufacturers",
                newName: "CarManufacturerId");
        }
    }
}
