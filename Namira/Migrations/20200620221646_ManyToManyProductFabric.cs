using Microsoft.EntityFrameworkCore.Migrations;

namespace Namira.Migrations
{
    public partial class ManyToManyProductFabric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "ProductId",
            //    table: "Fabrics",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "ProductFabric",
            //    columns: table => new
            //    {
            //        ProductId = table.Column<int>(nullable: false),
            //        FabricId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductFabric", x => new { x.ProductId, x.FabricId });
            //        table.ForeignKey(
            //            name: "FK_ProductFabric_Fabrics_FabricId",
            //            column: x => x.FabricId,
            //            principalTable: "Fabrics",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductFabric_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Fabrics_ProductId",
            //    table: "Fabrics",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductFabric_FabricId",
            //    table: "ProductFabric",
            //    column: "FabricId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Fabrics_Products_ProductId",
            //    table: "Fabrics",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fabrics_Products_ProductId",
                table: "Fabrics");

            migrationBuilder.DropTable(
                name: "ProductFabric");

            migrationBuilder.DropIndex(
                name: "IX_Fabrics_ProductId",
                table: "Fabrics");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Fabrics");
        }
    }
}
