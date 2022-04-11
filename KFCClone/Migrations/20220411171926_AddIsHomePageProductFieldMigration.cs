using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KFCClone.Migrations
{
    public partial class AddIsHomePageProductFieldMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<bool>(
                name: "is_home_page_product",
                table: "Products",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_home_page_product",
                table: "Products");


        }
    }
}
