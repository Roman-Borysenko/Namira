using Microsoft.EntityFrameworkCore.Migrations;

namespace Namira.Migrations
{
    public partial class RemoveFabricsWithProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Fabrics_Products_ProductId",
            //    table: "Fabrics");

            //migrationBuilder.DropIndex(
            //    name: "IX_Fabrics_ProductId",
            //    table: "Fabrics");

            //migrationBuilder.DropColumn(
            //    name: "ProductId",
            //    table: "Fabrics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Fabrics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fabrics_ProductId",
                table: "Fabrics",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fabrics_Products_ProductId",
                table: "Fabrics",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
