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
            migrationBuilder.DropTable(
                name: "BrakeTypes");

            migrationBuilder.DropColumn(
                name: "IsElectric",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "IsHybrid",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "PowerTrainId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleSpecId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FrontBrakeTypes",
                columns: table => new
                {
                    FrontBrakeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrontBrakeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontBrakeTypes", x => x.FrontBrakeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PowerTrains",
                columns: table => new
                {
                    PowerTrainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PowerTrainType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerTrains", x => x.PowerTrainId);
                });

            migrationBuilder.CreateTable(
                name: "RearBrakeTypes",
                columns: table => new
                {
                    RearBrakeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RearBrakeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RearBrakeTypes", x => x.RearBrakeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDimensionFuels",
                columns: table => new
                {
                    DimensionFuelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DimensionX = table.Column<float>(type: "real", nullable: false),
                    DimensionY = table.Column<float>(type: "real", nullable: false),
                    DimensionZ = table.Column<float>(type: "real", nullable: false),
                    GroundClearance = table.Column<float>(type: "real", nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    PayloadCapacity = table.Column<float>(type: "real", nullable: false),
                    FuelCapacity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDimensionFuels", x => x.DimensionFuelId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleFeatures",
                columns: table => new
                {
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.CreateTable(
                name: "VehiclePerformances",
                columns: table => new
                {
                    PerformanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransmissionTypeId = table.Column<int>(type: "int", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chassis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drivetrain = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePerformances", x => x.PerformanceId);
                    table.ForeignKey(
                        name: "FK_VehiclePerformances_TransmissionTypes_TransmissionTypeId",
                        column: x => x.TransmissionTypeId,
                        principalTable: "TransmissionTypes",
                        principalColumn: "TransmissionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTechnicals",
                columns: table => new
                {
                    TechnicalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatteryTypeId = table.Column<int>(type: "int", nullable: true),
                    SteeringSystemId = table.Column<int>(type: "int", nullable: true),
                    SteeringTypeId = table.Column<int>(type: "int", nullable: true),
                    PowerSteeringTypeId = table.Column<int>(type: "int", nullable: true),
                    FrontBrakeTypeId = table.Column<int>(type: "int", nullable: true),
                    RearBrakeTypeId = table.Column<int>(type: "int", nullable: true),
                    FuelTypeId = table.Column<int>(type: "int", nullable: true),
                    Suspension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumTurningRadius = table.Column<float>(type: "real", nullable: false),
                    AntiLockBrakeSystem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTechnicals", x => x.TechnicalId);
                    table.ForeignKey(
                        name: "FK_VehicleTechnicals_BatteryTypes_BatteryTypeId",
                        column: x => x.BatteryTypeId,
                        principalTable: "BatteryTypes",
                        principalColumn: "BatteryTypeId");
                    table.ForeignKey(
                        name: "FK_VehicleTechnicals_FrontBrakeTypes_FrontBrakeTypeId",
                        column: x => x.FrontBrakeTypeId,
                        principalTable: "FrontBrakeTypes",
                        principalColumn: "FrontBrakeTypeId");
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
                        name: "FK_VehicleTechnicals_RearBrakeTypes_RearBrakeTypeId",
                        column: x => x.RearBrakeTypeId,
                        principalTable: "RearBrakeTypes",
                        principalColumn: "RearBrakeTypeId");
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

            migrationBuilder.CreateTable(
                name: "VehicleSpecs",
                columns: table => new
                {
                    VehicleSpecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerformanceId = table.Column<int>(type: "int", nullable: true),
                    TechnicalId = table.Column<int>(type: "int", nullable: true),
                    DimensionFuelId = table.Column<int>(type: "int", nullable: true),
                    FeatureId = table.Column<int>(type: "int", nullable: true),
                    Disclaimer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelNote = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleSpecs", x => x.VehicleSpecId);
                    table.ForeignKey(
                        name: "FK_VehicleSpecs_VehicleDimensionFuels_DimensionFuelId",
                        column: x => x.DimensionFuelId,
                        principalTable: "VehicleDimensionFuels",
                        principalColumn: "DimensionFuelId");
                    table.ForeignKey(
                        name: "FK_VehicleSpecs_VehicleFeatures_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "VehicleFeatures",
                        principalColumn: "FeatureId");
                    table.ForeignKey(
                        name: "FK_VehicleSpecs_VehiclePerformances_PerformanceId",
                        column: x => x.PerformanceId,
                        principalTable: "VehiclePerformances",
                        principalColumn: "PerformanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleSpecs_VehicleTechnicals_TechnicalId",
                        column: x => x.TechnicalId,
                        principalTable: "VehicleTechnicals",
                        principalColumn: "TechnicalId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_PowerTrainId",
                table: "Vehicles",
                column: "PowerTrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleSpecId",
                table: "Vehicles",
                column: "VehicleSpecId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePerformanceDriveModes_DriveModeId",
                table: "VehiclePerformanceDriveModes",
                column: "DriveModeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePerformances_TransmissionTypeId",
                table: "VehiclePerformances",
                column: "TransmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSpecs_DimensionFuelId",
                table: "VehicleSpecs",
                column: "DimensionFuelId",
                unique: true,
                filter: "[DimensionFuelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSpecs_FeatureId",
                table: "VehicleSpecs",
                column: "FeatureId",
                unique: true,
                filter: "[FeatureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSpecs_PerformanceId",
                table: "VehicleSpecs",
                column: "PerformanceId",
                unique: true,
                filter: "[PerformanceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSpecs_TechnicalId",
                table: "VehicleSpecs",
                column: "TechnicalId",
                unique: true,
                filter: "[TechnicalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTechnicals_BatteryTypeId",
                table: "VehicleTechnicals",
                column: "BatteryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTechnicals_FrontBrakeTypeId",
                table: "VehicleTechnicals",
                column: "FrontBrakeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTechnicals_FuelTypeId",
                table: "VehicleTechnicals",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTechnicals_PowerSteeringTypeId",
                table: "VehicleTechnicals",
                column: "PowerSteeringTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTechnicals_RearBrakeTypeId",
                table: "VehicleTechnicals",
                column: "RearBrakeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTechnicals_SteeringSystemId",
                table: "VehicleTechnicals",
                column: "SteeringSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTechnicals_SteeringTypeId",
                table: "VehicleTechnicals",
                column: "SteeringTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_PowerTrains_PowerTrainId",
                table: "Vehicles",
                column: "PowerTrainId",
                principalTable: "PowerTrains",
                principalColumn: "PowerTrainId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleSpecs_VehicleSpecId",
                table: "Vehicles",
                column: "VehicleSpecId",
                principalTable: "VehicleSpecs",
                principalColumn: "VehicleSpecId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_PowerTrains_PowerTrainId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleSpecs_VehicleSpecId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "PowerTrains");

            migrationBuilder.DropTable(
                name: "VehiclePerformanceDriveModes");

            migrationBuilder.DropTable(
                name: "VehicleSpecs");

            migrationBuilder.DropTable(
                name: "VehicleDimensionFuels");

            migrationBuilder.DropTable(
                name: "VehicleFeatures");

            migrationBuilder.DropTable(
                name: "VehiclePerformances");

            migrationBuilder.DropTable(
                name: "VehicleTechnicals");

            migrationBuilder.DropTable(
                name: "FrontBrakeTypes");

            migrationBuilder.DropTable(
                name: "RearBrakeTypes");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_PowerTrainId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleSpecId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "PowerTrainId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleSpecId",
                table: "Vehicles");

            migrationBuilder.AddColumn<bool>(
                name: "IsElectric",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHybrid",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "BrakeTypes",
                columns: table => new
                {
                    BrakeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrakeTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrakeTypes", x => x.BrakeTypeId);
                });
        }
    }
}
