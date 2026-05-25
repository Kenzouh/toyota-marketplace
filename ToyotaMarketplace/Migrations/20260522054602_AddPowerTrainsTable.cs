using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToyotaMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class AddPowerTrainsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_PowerTrainId",
                table: "Vehicles",
                column: "PowerTrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_PowerTrains_PowerTrainId",
                table: "Vehicles",
                column: "PowerTrainId",
                principalTable: "PowerTrains",
                principalColumn: "PowerTrainId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_PowerTrains_PowerTrainId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "PowerTrains");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_PowerTrainId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "PowerTrainId",
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
        }
    }
}
