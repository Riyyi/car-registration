using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRegistration.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "CarManufacturers");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CarManufacturerId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_CarManufacturers_CarManufacturerId",
                        column: x => x.CarManufacturerId,
                        principalTable: "CarManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CarManufacturerId",
                table: "Brands",
                column: "CarManufacturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "CarManufacturers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
