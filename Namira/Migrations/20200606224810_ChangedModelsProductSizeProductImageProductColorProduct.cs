using Microsoft.EntityFrameworkCore.Migrations;

namespace Namira.Migrations
{
    public partial class ChangedModelsProductSizeProductImageProductColorProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductColors_ProductColorsId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductColorsId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ProductColorsId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "NameColor",
                table: "ProductColors");

            migrationBuilder.AddColumn<int>(
                name: "ProductColorId",
                table: "ProductImages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductSize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ProductColorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSize_ProductColors_ProductColorId",
                        column: x => x.ProductColorId,
                        principalTable: "ProductColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSize_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductColorId",
                table: "ProductImages",
                column: "ProductColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_ProductColorId",
                table: "ProductSize",
                column: "ProductColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_SizeId",
                table: "ProductSize",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductColors_ProductColorId",
                table: "ProductImages",
                column: "ProductColorId",
                principalTable: "ProductColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductColors_ProductColorId",
                table: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductColorId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ProductColorId",
                table: "ProductImages");

            migrationBuilder.AddColumn<int>(
                name: "ProductColorsId",
                table: "ProductImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameColor",
                table: "ProductColors",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductColorsId",
                table: "ProductImages",
                column: "ProductColorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductColors_ProductColorsId",
                table: "ProductImages",
                column: "ProductColorsId",
                principalTable: "ProductColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
