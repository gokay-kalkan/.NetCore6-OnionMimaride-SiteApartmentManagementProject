using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartmentManagement.Persistence.Migrations
{
    public partial class duesremovedelayedpaymentcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelayedPayment",
                table: "Dues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DelayedPayment",
                table: "Dues",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
