using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoIoT.Infrastructure.Persistence.Migrations
{
    public partial class update_devices_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Devices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Devices",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Devices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Devices",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ValueEndTo",
                table: "Devices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValueStartFrom",
                table: "Devices",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "ValueEndTo",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "ValueStartFrom",
                table: "Devices");
        }
    }
}
