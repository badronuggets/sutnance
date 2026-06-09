using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sutnance.Migrations
{
    /// <inheritdoc />
    public partial class _14061 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MachineId",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ReportId",
                table: "Historiques",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MachineId",
                table: "Historiques",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Historiques_Reports_ReportId",
                table: "Historiques",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Machines_MachineId",
                table: "Reports",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id");
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

            migrationBuilder.AlterColumn<string>(
                name: "MachineId",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ReportId",
                table: "Historiques",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "MachineId",
                table: "Historiques",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
