using Microsoft.EntityFrameworkCore.Migrations;

namespace Namira.Migrations
{
    public partial class RenamePropertyColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Colors",
            //    table: "ProductColors");

            //migrationBuilder.AddColumn<string>(
            //    name: "Color",
            //    table: "ProductColors",
            //    maxLength: 7,
            //    nullable: false,
            //    defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "ProductColors");

            migrationBuilder.AddColumn<string>(
                name: "Colors",
                table: "ProductColors",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");
        }
    }
}
