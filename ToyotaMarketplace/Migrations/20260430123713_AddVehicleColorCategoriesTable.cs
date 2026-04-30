using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToyotaMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleColorCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleColorCategoryId",
                table: "VehicleColors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VehicleColorCategories",
                columns: table => new
                {
                    VehicleColorCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleColorCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleColorCategories", x => x.VehicleColorCategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleColors_VehicleColorCategoryId",
                table: "VehicleColors",
                column: "VehicleColorCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleColors_VehicleColorCategories_VehicleColorCategoryId",
                table: "VehicleColors",
                column: "VehicleColorCategoryId",
                principalTable: "VehicleColorCategories",
                principalColumn: "VehicleColorCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleColors_VehicleColorCategories_VehicleColorCategoryId",
                table: "VehicleColors");

            migrationBuilder.DropTable(
                name: "VehicleColorCategories");

            migrationBuilder.DropIndex(
                name: "IX_VehicleColors_VehicleColorCategoryId",
                table: "VehicleColors");

            migrationBuilder.DropColumn(
                name: "VehicleColorCategoryId",
                table: "VehicleColors");
        }
    }
}
