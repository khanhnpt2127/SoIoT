using Microsoft.EntityFrameworkCore.Migrations;

namespace SoIoT.Infrastructure.Migrations
{
    public partial class fixmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_SensorUnits_SensorUnitId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_SensorUnitId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "SensorUnitId",
                table: "Devices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SensorUnitId",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_SensorUnitId",
                table: "Devices",
                column: "SensorUnitId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_SensorUnits_SensorUnitId",
                table: "Devices",
                column: "SensorUnitId",
                principalTable: "SensorUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
