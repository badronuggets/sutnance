using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sutnance.Migrations
{
    /// <inheritdoc />
    public partial class importantstuff3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MachineId",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BootTime",
                table: "Machines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "Machines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Machines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Site",
                table: "Machines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Machines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MachineId",
                table: "Historiques",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReportId",
                table: "Historiques",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Historiques",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TraitePar",
                table: "Historiques",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_MachineId",
                table: "Reports",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Historiques_MachineId",
                table: "Historiques",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Historiques_ReportId",
                table: "Historiques",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Historiques_Machines_MachineId",
                table: "Historiques",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Historiques_Reports_ReportId",
                table: "Historiques",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Machines_MachineId",
                table: "Reports",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historiques_Machines_MachineId",
                table: "Historiques");

            migrationBuilder.DropForeignKey(
                name: "FK_Historiques_Reports_ReportId",
                table: "Historiques");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Machines_MachineId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_MachineId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Historiques_MachineId",
                table: "Historiques");

            migrationBuilder.DropIndex(
                name: "IX_Historiques_ReportId",
                table: "Historiques");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "BootTime",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "Ip",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "Site",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "Historiques");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Historiques");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Historiques");

            migrationBuilder.DropColumn(
                name: "TraitePar",
                table: "Historiques");
        }
    }
}
