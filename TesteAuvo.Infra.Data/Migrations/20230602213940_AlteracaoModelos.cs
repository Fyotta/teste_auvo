using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteAuvo.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTimeRecords_Departments_DepartmentId",
                table: "EmployeeTimeRecords");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "EmployeeTimeRecords",
                newName: "BookEmployeeTimeRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTimeRecords_DepartmentId",
                table: "EmployeeTimeRecords",
                newName: "IX_EmployeeTimeRecords_BookEmployeeTimeRecordId");

            migrationBuilder.CreateTable(
                name: "BookEmployeeTimeRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EffectiveMonth = table.Column<int>(type: "INTEGER", nullable: false),
                    EffectiveYear = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEmployeeTimeRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookEmployeeTimeRecord_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookEmployeeTimeRecord_DepartmentId",
                table: "BookEmployeeTimeRecord",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTimeRecords_BookEmployeeTimeRecord_BookEmployeeTimeRecordId",
                table: "EmployeeTimeRecords",
                column: "BookEmployeeTimeRecordId",
                principalTable: "BookEmployeeTimeRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTimeRecords_BookEmployeeTimeRecord_BookEmployeeTimeRecordId",
                table: "EmployeeTimeRecords");

            migrationBuilder.DropTable(
                name: "BookEmployeeTimeRecord");

            migrationBuilder.RenameColumn(
                name: "BookEmployeeTimeRecordId",
                table: "EmployeeTimeRecords",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTimeRecords_BookEmployeeTimeRecordId",
                table: "EmployeeTimeRecords",
                newName: "IX_EmployeeTimeRecords_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTimeRecords_Departments_DepartmentId",
                table: "EmployeeTimeRecords",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
