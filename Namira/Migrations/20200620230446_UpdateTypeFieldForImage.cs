using Microsoft.EntityFrameworkCore.Migrations;

namespace Namira.Migrations
{
    public partial class UpdateTypeFieldForImage : Migration
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

            //migrationBuilder.AlterColumn<string>(
            //    name: "Foreground",
            //    table: "Products",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Background",
            //    table: "Products",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Image",
            //    table: "ProductImages",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Foreground",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Background",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

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
