using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToyotaMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleSpecsLookupTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrakeTypeName",
                table: "BrakeTypes",
                newName: "RearBrake");

            migrationBuilder.AddColumn<string>(
                name: "FrontBrake",
                table: "BrakeTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "VehicleSpecs",
                columns: table => new
                {
                    VehicleSpecId = table.Column<int>(type: "int", nullable: false),
                    PerformanceId = table.Column<int>(type: "int", nullable: true),
                    TechnicalId = table.Column<int>(type: "int", nullable: true),
                    DimensionFuelId = table.Column<int>(type: "int", nullable: true),
                    FeatureId = table.Column<int>(type: "int", nullable: true),
                    Disclaimer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroundClearance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleSpecs", x => x.VehicleSpecId);
                    table.ForeignKey(
                        name: "FK_VehicleSpecs_Vehicles_VehicleSpecId",
                        column: x => x.VehicleSpecId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDimensionFuels",
                columns: table => new
                {
                    DimensionFuelId = table.Column<int>(type: "int", nullable: false),
                    Dimension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroundClearance = table.Column<float>(type: "real", nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    PayloadCapacity = table.Column<float>(type: "real", nullable: false),
                    FuelCapacity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDimensionFuels", x => x.DimensionFuelId);
                    table.ForeignKey(
                        name: "FK_VehicleDimensionFuels_VehicleSpecs_DimensionFuelId",
                        column: x => x.DimensionFuelId,
                        principalTable: "VehicleSpecs",
                        principalColumn: "VehicleSpecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleFeatures",
                columns: table => new
                {
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    Exterior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TireDiskWheel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Audio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeterCluster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MultiInfoDisplay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Safety = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ignition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleFeatures", x => x.FeatureId);
                    table.ForeignKey(
                        name: "FK_VehicleFeatures_VehicleSpecs_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "VehicleSpecs",
                        principalColumn: "VehicleSpecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePerformances",
                columns: table => new
                {
                    PerformanceId = table.Column<int>(type: "int", nullable: false),
                    TransmissionTypeId = table.Column<int>(type: "int", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chassis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drivetrain = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePerformances", x => x.PerformanceId);
                    table.ForeignKey(
                        name: "FK_VehiclePerformances_VehicleSpecs_PerformanceId",
                        column: x => x.PerformanceId,
                        principalTable: "VehicleSpecs",
                        principalColumn: "VehicleSpecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTechnicals",
                columns: table => new
                {
                    TechnicalId = table.Column<int>(type: "int", nullable: false),
                    BatteryTypeId = table.Column<int>(type: "int", nullable: true),
                    SteeringSystemId = table.Column<int>(type: "int", nullable: true),
                    SteeringTypeId = table.Column<int>(type: "int", nullable: true),
                    PowerSteeringTypeId = table.Column<int>(type: "int", nullable: true),
                    BrakeTypeId = table.Column<int>(type: "int", nullable: true),
                    FuelTypeId = table.Column<int>(type: "int", nullable: true),
                    Suspension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumTurningRadius = table.Column<float>(type: "real", nullable: false),
                    AntiLockBrakeSystem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTechnicals", x => x.TechnicalId);
                    table.ForeignKey(
                        name: "FK_VehicleTechnicals_BatteryTypes_TechnicalId",
                        column: x => x.TechnicalId,
                        principalTable: "BatteryTypes",
                        principalColumn: "BatteryTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleTechnicals_BrakeTypes_BrakeTypeId",
                        column: x => x.BrakeTypeId,
                        principalTable: "BrakeTypes",
                        principalColumn: "BrakeTypeId");
                    table.ForeignKey(
                        name: "FK_VehicleTechnicals_FuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelTypes",
                        principalColumn: "FuelTypeId");
                    table.ForeignKey(
                        name: "FK_VehicleTechnicals_PowerSteeringTypes_PowerSteeringTypeId",
                        column: x => x.PowerSteeringTypeId,
                        principalTable: "PowerSteeringTypes",
                        principalColumn: "PowerSteeringTypeId");
                    table.ForeignKey(
                        name: "FK_VehicleTechnicals_SteeringSystems_SteeringSystemId",
                        column: x => x.SteeringSystemId,
                        principalTable: "SteeringSystems",
                        principalColumn: "SteeringSystemId");
                    table.ForeignKey(
                        name: "FK_VehicleTechnicals_SteeringTypes_SteeringTypeId",
                        column: x => x.SteeringTypeId,
                        principalTable: "SteeringTypes",
                        principalColumn: "SteeringTypeId");
                    table.ForeignKey(
                        name: "FK_VehicleTechnicals_VehicleSpecs_TechnicalId",
                        column: x => x.TechnicalId,
                        principalTable: "VehicleSpecs",
                        principalColumn: "VehicleSpecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePerformanceDriveModes",
                columns: table => new
                {
                    PerformanceId = table.Column<int>(type: "int", nullable: false),
                    DriveModeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePerformanceDriveModes", x => new { x.PerformanceId, x.DriveModeId });
                    table.ForeignKey(
                        name: "FK_VehiclePerformanceDriveModes_DriveModes_DriveModeId",
                        column: x => x.DriveModeId,
                        principalTable: "DriveModes",
                        principalColumn: "DriveModeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePerformanceDriveModes_VehiclePerformances_PerformanceId",
                        column: x => x.PerformanceId,
                        principalTable: "VehiclePerformances",
                        principalColumn: "PerformanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePerformanceDriveModes_DriveModeId",
                table: "VehiclePerformanceDriveModes",
                column: "DriveModeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTechnicals_BrakeTypeId",
                table: "VehicleTechnicals",
                column: "BrakeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTechnicals_FuelTypeId",
                table: "VehicleTechnicals",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTechnicals_PowerSteeringTypeId",
                table: "VehicleTechnicals",
                column: "PowerSteeringTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTechnicals_SteeringSystemId",
                table: "VehicleTechnicals",
                column: "SteeringSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTechnicals_SteeringTypeId",
                table: "VehicleTechnicals",
                column: "SteeringTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleDimensionFuels");

            migrationBuilder.DropTable(
                name: "VehicleFeatures");

            migrationBuilder.DropTable(
                name: "VehiclePerformanceDriveModes");

            migrationBuilder.DropTable(
                name: "VehicleTechnicals");

            migrationBuilder.DropTable(
                name: "VehiclePerformances");

            migrationBuilder.DropTable(
                name: "VehicleSpecs");

            migrationBuilder.DropColumn(
                name: "FrontBrake",
                table: "BrakeTypes");

            migrationBuilder.RenameColumn(
                name: "RearBrake",
                table: "BrakeTypes",
                newName: "BrakeTypeName");
        }
    }
}
