using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Namira.Migrations
{
    public partial class InitialProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Brands",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(maxLength: 120, nullable: false),
            //        Slug = table.Column<string>(maxLength: 140, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Brands", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Currencies",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(maxLength: 50, nullable: false),
            //        Slug = table.Column<string>(maxLength: 60, nullable: false),
            //        Reduction = table.Column<string>(maxLength: 3, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Currencies", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Languages",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(maxLength: 50, nullable: false),
            //        Slug = table.Column<string>(maxLength: 60, nullable: false),
            //        Reduction = table.Column<string>(maxLength: 2, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Languages", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Sizes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(maxLength: 120, nullable: false),
            //        Slug = table.Column<string>(maxLength: 140, nullable: false),
            //        Reduction = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Sizes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(maxLength: 120, nullable: false),
            //        Slug = table.Column<string>(nullable: true),
            //        MetaDescription = table.Column<string>(maxLength: 1000, nullable: false),
            //        MetaKeywords = table.Column<string>(maxLength: 1000, nullable: false),
            //        LanguageId = table.Column<int>(nullable: true),
            //        CategoryId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Categories_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Categories_Languages_LanguageId",
            //            column: x => x.LanguageId,
            //            principalTable: "Languages",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Countries",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(maxLength: 50, nullable: false),
            //        Slug = table.Column<string>(maxLength: 60, nullable: false),
            //        LanguageId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Countries", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Countries_Languages_LanguageId",
            //            column: x => x.LanguageId,
            //            principalTable: "Languages",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Products",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CategoryId = table.Column<int>(nullable: false),
            //        Name = table.Column<string>(maxLength: 120, nullable: false),
            //        Slug = table.Column<string>(maxLength: 130, nullable: false),
            //        LanguageId = table.Column<int>(nullable: false),
            //        ProductCode = table.Column<int>(nullable: false),
            //        Price = table.Column<decimal>(nullable: false),
            //        Discount = table.Column<int>(nullable: false),
            //        Raiting = table.Column<int>(nullable: false),
            //        View = table.Column<int>(nullable: false),
            //        CountryId = table.Column<int>(nullable: false),
            //        Description = table.Column<string>(maxLength: 10000, nullable: false),
            //        MetaDescription = table.Column<string>(maxLength: 1000, nullable: false),
            //        MetaKeywords = table.Column<string>(maxLength: 1000, nullable: false),
            //        BrandId = table.Column<int>(nullable: false),
            //        Foreground = table.Column<string>(maxLength: 200, nullable: false),
            //        Background = table.Column<string>(maxLength: 200, nullable: false),
            //        Create = table.Column<DateTime>(nullable: false),
            //        Update = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Products", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Products_Brands_BrandId",
            //            column: x => x.BrandId,
            //            principalTable: "Brands",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Products_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Products_Countries_CountryId",
            //            column: x => x.CountryId,
            //            principalTable: "Countries",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Products_Languages_LanguageId",
            //            column: x => x.LanguageId,
            //            principalTable: "Languages",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Fabrics",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(maxLength: 120, nullable: false),
            //        Slug = table.Column<string>(maxLength: 140, nullable: false),
            //        LanguageId = table.Column<int>(nullable: true),
            //        ProductId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Fabrics", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Fabrics_Languages_LanguageId",
            //            column: x => x.LanguageId,
            //            principalTable: "Languages",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Fabrics_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "NumberPurchases",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductId = table.Column<int>(nullable: false),
            //        Date = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NumberPurchases", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_NumberPurchases_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductColors",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductId = table.Column<int>(nullable: false),
            //        NameColor = table.Column<string>(maxLength: 30, nullable: false),
            //        Colors = table.Column<string>(maxLength: 7, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductColors", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProductColors_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductSizes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductId = table.Column<int>(nullable: false),
            //        SizeId = table.Column<int>(nullable: false),
            //        Quantity = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductSizes", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProductSizes_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductSizes_Sizes_SizeId",
            //            column: x => x.SizeId,
            //            principalTable: "Sizes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductImages",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductColorsId = table.Column<int>(nullable: false),
            //        ImagePath = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductImages", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProductImages_ProductColors_ProductColorsId",
            //            column: x => x.ProductColorsId,
            //            principalTable: "ProductColors",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Categories_CategoryId",
            //    table: "Categories",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Categories_LanguageId",
            //    table: "Categories",
            //    column: "LanguageId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Countries_LanguageId",
            //    table: "Countries",
            //    column: "LanguageId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Fabrics_LanguageId",
            //    table: "Fabrics",
            //    column: "LanguageId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Fabrics_ProductId",
            //    table: "Fabrics",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_NumberPurchases_ProductId",
            //    table: "NumberPurchases",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductColors_ProductId",
            //    table: "ProductColors",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductImages_ProductColorsId",
            //    table: "ProductImages",
            //    column: "ProductColorsId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_BrandId",
            //    table: "Products",
            //    column: "BrandId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_CategoryId",
            //    table: "Products",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_CountryId",
            //    table: "Products",
            //    column: "CountryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_LanguageId",
            //    table: "Products",
            //    column: "LanguageId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductSizes_ProductId",
            //    table: "ProductSizes",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductSizes_SizeId",
            //    table: "ProductSizes",
            //    column: "SizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Fabrics");

            migrationBuilder.DropTable(
                name: "NumberPurchases");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
