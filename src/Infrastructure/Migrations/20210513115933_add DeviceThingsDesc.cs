using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoIoT.Infrastructure.Migrations
{
    public partial class addDeviceThingsDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceThingsDescId",
                table: "Devices",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeviceThingsDescs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceThingsDescs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceThingsDescId",
                table: "Devices",
                column: "DeviceThingsDescId",
                unique: true,
                filter: "[DeviceThingsDescId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceThingsDescs_DeviceThingsDescId",
                table: "Devices",
                column: "DeviceThingsDescId",
                principalTable: "DeviceThingsDescs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceThingsDescs_DeviceThingsDescId",
                table: "Devices");

            migrationBuilder.DropTable(
                name: "DeviceThingsDescs");

            migrationBuilder.DropIndex(
                name: "IX_Devices_DeviceThingsDescId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "DeviceThingsDescId",
                table: "Devices");
        }
    }
}
