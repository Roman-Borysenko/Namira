using Microsoft.EntityFrameworkCore.Migrations;

namespace Namira.Migrations
{
    public partial class AddedFieldLanguageGroupForFabricModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LanguageGroup",
                table: "Fabrics",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageGroup",
                table: "Fabrics");
        }
    }
}
