using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteAuvo.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                name: "BookEmployeeTimeRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EffectiveMonth = table.Column<int>(type: "INTEGER", nullable: false),
                    EffectiveYear = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEmployeeTimeRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookEmployeeTimeRecords_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookEmployeeTimeRecordId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTimeRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTimeRecords_BookEmployeeTimeRecords_BookEmployeeTimeRecordId",
                        column: x => x.BookEmployeeTimeRecordId,
                        principalTable: "BookEmployeeTimeRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTimeRecords_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheetClosures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookEmployeeTimeRecordId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TotalPayment = table.Column<double>(type: "REAL", nullable: false),
                    TotalDeductions = table.Column<double>(type: "REAL", nullable: false),
                    TotalOvertime = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheetClosures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheetClosures_BookEmployeeTimeRecords_BookEmployeeTimeRecordId",
                        column: x => x.BookEmployeeTimeRecordId,
                        principalTable: "BookEmployeeTimeRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TotalEarnings = table.Column<double>(type: "REAL", nullable: false),
                    OvertimeHours = table.Column<double>(type: "REAL", nullable: false),
                    OvertimePayment = table.Column<double>(type: "REAL", nullable: false),
                    DebitHours = table.Column<double>(type: "REAL", nullable: false),
                    MissingHoursDeduction = table.Column<double>(type: "REAL", nullable: false),
                    AbsentDays = table.Column<int>(type: "INTEGER", nullable: false),
                    ExtraDays = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkedDays = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeSheetClosureId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOrders_TimeSheetClosures_TimeSheetClosureId",
                        column: x => x.TimeSheetClosureId,
                        principalTable: "TimeSheetClosures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookEmployeeTimeRecords_DepartmentId",
                table: "BookEmployeeTimeRecords",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimeRecords_BookEmployeeTimeRecordId",
                table: "EmployeeTimeRecords",
                column: "BookEmployeeTimeRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimeRecords_EmployeeId",
                table: "EmployeeTimeRecords",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_EmployeeId",
                table: "PaymentOrders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrders_TimeSheetClosureId",
                table: "PaymentOrders",
                column: "TimeSheetClosureId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetClosures_BookEmployeeTimeRecordId",
                table: "TimeSheetClosures",
                column: "BookEmployeeTimeRecordId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTimeRecords");

            migrationBuilder.DropTable(
                name: "PaymentOrders");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TimeSheetClosures");

            migrationBuilder.DropTable(
                name: "BookEmployeeTimeRecords");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
