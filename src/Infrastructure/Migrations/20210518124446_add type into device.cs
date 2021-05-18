using Microsoft.EntityFrameworkCore.Migrations;

namespace SoIoT.Infrastructure.Migrations
{
    public partial class addtypeintodevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Devices",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Devices");
        }
    }
}
