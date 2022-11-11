using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartmentManagement.Persistence.Migrations
{
    public partial class duesandduespaymentrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DuesId",
                table: "DuesPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DuesPayments_DuesId",
                table: "DuesPayments",
                column: "DuesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DuesPayments_Dues_DuesId",
                table: "DuesPayments",
                column: "DuesId",
                principalTable: "Dues",
                principalColumn: "DuesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuesPayments_Dues_DuesId",
                table: "DuesPayments");

            migrationBuilder.DropIndex(
                name: "IX_DuesPayments_DuesId",
                table: "DuesPayments");

            migrationBuilder.DropColumn(
                name: "DuesId",
                table: "DuesPayments");
        }
    }
}
