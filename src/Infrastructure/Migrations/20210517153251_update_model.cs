using Microsoft.EntityFrameworkCore.Migrations;

namespace SoIoT.Infrastructure.Migrations
{
    public partial class update_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueEndTo",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "ValueStartFrom",
                table: "Devices");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "SensorLogs",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "SensorLogs",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ValueEndTo",
                table: "Devices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValueStartFrom",
                table: "Devices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
