using Microsoft.EntityFrameworkCore.Migrations;

namespace PayCompute.Persistence.Migrations
{
    public partial class UpadateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SLC",
                table: "PaymentRecords");

            migrationBuilder.DropColumn(
                name: "UnionFee",
                table: "PaymentRecords");

            migrationBuilder.DropColumn(
                name: "StudentLoan",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UnionMember",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SLC",
                table: "PaymentRecords",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnionFee",
                table: "PaymentRecords",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentLoan",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnionMember",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
