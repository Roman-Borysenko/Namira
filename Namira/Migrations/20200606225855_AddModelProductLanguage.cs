using Microsoft.EntityFrameworkCore.Migrations;

namespace Namira.Migrations
{
    public partial class AddModelProductLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Languages_LanguageId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_LanguageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetaKeywords",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: false),
                    Slug = table.Column<string>(maxLength: 130, nullable: false),
                    Description = table.Column<string>(maxLength: 10000, nullable: false),
                    MetaDescription = table.Column<string>(maxLength: 1000, nullable: false),
                    MetaKeywords = table.Column<string>(maxLength: 1000, nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductLanguages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductLanguages_LanguageId",
                table: "ProductLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLanguages_ProductId",
                table: "ProductLanguages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLanguages");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MetaKeywords",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Products",
                type: "nvarchar(130)",
                maxLength: 130,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LanguageId",
                table: "Products",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Languages_LanguageId",
                table: "Products",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
