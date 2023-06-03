using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteAuvo.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixEmployeeTimeRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EffectiveMonth",
                table: "EmployeeTimeRecords");

            migrationBuilder.DropColumn(
                name: "EffectiveYear",
                table: "EmployeeTimeRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EffectiveMonth",
                table: "EmployeeTimeRecords",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EffectiveYear",
                table: "EmployeeTimeRecords",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
