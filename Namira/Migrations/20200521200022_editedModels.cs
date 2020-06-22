using Microsoft.EntityFrameworkCore.Migrations;

namespace Namira.Migrations
{
    public partial class editedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Categories_Languages_LanguageId",
            //    table: "Categories");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Countries_Languages_LanguageId",
            //    table: "Countries");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Fabrics_Languages_LanguageId",
            //    table: "Fabrics");

            //migrationBuilder.DropIndex(
            //    name: "IX_Countries_LanguageId",
            //    table: "Countries");

            //migrationBuilder.DropIndex(
            //    name: "IX_Categories_LanguageId",
            //    table: "Categories");

            //migrationBuilder.DropColumn(
            //    name: "LanguageId",
            //    table: "Countries");

            //migrationBuilder.AlterColumn<int>(
            //    name: "LanguageId",
            //    table: "Fabrics",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "LanguageId",
            //    table: "Categories",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Fabrics_Languages_LanguageId",
            //    table: "Fabrics",
            //    column: "LanguageId",
            //    principalTable: "Languages",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fabrics_Languages_LanguageId",
                table: "Fabrics");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "Fabrics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LanguageId",
                table: "Countries",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LanguageId",
                table: "Categories",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Languages_LanguageId",
                table: "Categories",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Languages_LanguageId",
                table: "Countries",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fabrics_Languages_LanguageId",
                table: "Fabrics",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
