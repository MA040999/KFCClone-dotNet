using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KFCClone.Migrations
{
    public partial class PaymentTypeAndPersistInfoFeild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "payment_type",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "payment_type",
                table: "Orders");
        }
    }
}
