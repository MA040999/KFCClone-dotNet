using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KFCClone.Migrations
{
    public partial class PromotionTableUrlColumnNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "url",
                table: "Promotions");

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "Promotions",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_id",
                table: "Promotions");

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "Promotions",
                type: "nvarchar(90)",
                maxLength: 90,
                nullable: true);
        }
    }
}
