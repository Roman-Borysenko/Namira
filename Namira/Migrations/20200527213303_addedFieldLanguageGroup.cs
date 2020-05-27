using Microsoft.EntityFrameworkCore.Migrations;

namespace Namira.Migrations
{
    public partial class addedFieldLanguageGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LanguageGroup",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageGroup",
                table: "Categories");
        }
    }
}
