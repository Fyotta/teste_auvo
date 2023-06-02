using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteAuvo.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExternalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTimeRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    HourlyRate = table.Column<double>(type: "REAL", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EntryTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    ExitTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    LunchPeriodStart = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    LunchPeriodEnd = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    EffectiveMonth = table.Column<int>(type: "INTEGER", nullable: false),
                    EffectiveYear = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTimeRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTimeRecords_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTimeRecords_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimeRecords_DepartmentId",
                table: "EmployeeTimeRecords",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimeRecords_EmployeeId",
                table: "EmployeeTimeRecords",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTimeRecords");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
