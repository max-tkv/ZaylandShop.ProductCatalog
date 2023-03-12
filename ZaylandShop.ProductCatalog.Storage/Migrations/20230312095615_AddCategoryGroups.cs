using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaylandShop.ProductCatalog.Storage.Migrations
{
    public partial class AddCategoryGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "Categories");
        }
    }
}
