using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToyotaMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class AddNavPropertyToTransmissionTypeInVehiclePerformanceTableAndVehicleSpecFKInVehicleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroundClearance",
                table: "VehicleSpecs");

            migrationBuilder.AddColumn<int>(
                name: "VehicleSpecId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePerformances_TransmissionTypeId",
                table: "VehiclePerformances",
                column: "TransmissionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePerformances_TransmissionTypes_TransmissionTypeId",
                table: "VehiclePerformances",
                column: "TransmissionTypeId",
                principalTable: "TransmissionTypes",
                principalColumn: "TransmissionTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePerformances_TransmissionTypes_TransmissionTypeId",
                table: "VehiclePerformances");

            migrationBuilder.DropIndex(
                name: "IX_VehiclePerformances_TransmissionTypeId",
                table: "VehiclePerformances");

            migrationBuilder.DropColumn(
                name: "VehicleSpecId",
                table: "Vehicles");

            migrationBuilder.AddColumn<float>(
                name: "GroundClearance",
                table: "VehicleSpecs",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
