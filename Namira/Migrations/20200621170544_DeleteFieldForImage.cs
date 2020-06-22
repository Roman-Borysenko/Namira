using Microsoft.EntityFrameworkCore.Migrations;

namespace Namira.Migrations
{
    public partial class DeleteFieldForImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Background",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Foreground",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ProductImages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Background",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Foreground",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ProductImages",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
