using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KFCClone.Migrations
{
    public partial class PaymentTypeAndPersistInfoFeild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "persist_info",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                name: "persist_info",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "payment_type",
                table: "Orders");
        }
    }
}
