using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRegistration.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarManufacturers",
                columns: new[] { "Id", "Address", "FoundingYear", "Name", "PhoneNumber" },
                values: new object[] { 1L, "Chinastreet 1", 1973, "Big manufacturer", "+86-13910998888" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CarManufacturerId", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, "VW" },
                    { 2L, 1L, "Audi" },
                    { 3L, 1L, "Skoda" },
                    { 4L, 1L, "Mercedes-Benz" },
                    { 5L, 1L, "Toyota" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BodyType", "Color", "InitialRegistrationDate", "LicensePlate", "MakeId", "Model", "Power", "VIN" },
                values: new object[] { 1L, "4-doors", "Blue", new DateTime(2011, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-DGP-63", 5L, "Aygo", 53, "4Y1SL65848Z411439" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "CarManufacturers",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
