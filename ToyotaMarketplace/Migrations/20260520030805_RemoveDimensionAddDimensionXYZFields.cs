using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToyotaMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDimensionAddDimensionXYZFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimension",
                table: "VehicleDimensionFuels");

            migrationBuilder.AddColumn<float>(
                name: "DimensionX",
                table: "VehicleDimensionFuels",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DimensionY",
                table: "VehicleDimensionFuels",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DimensionZ",
                table: "VehicleDimensionFuels",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DimensionX",
                table: "VehicleDimensionFuels");

            migrationBuilder.DropColumn(
                name: "DimensionY",
                table: "VehicleDimensionFuels");

            migrationBuilder.DropColumn(
                name: "DimensionZ",
                table: "VehicleDimensionFuels");

            migrationBuilder.AddColumn<string>(
                name: "Dimension",
                table: "VehicleDimensionFuels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
