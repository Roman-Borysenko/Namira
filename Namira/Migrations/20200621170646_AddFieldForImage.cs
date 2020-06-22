using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Namira.Migrations
{
    public partial class AddFieldForImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Background",
                table: "Products",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<byte[]>(
                name: "Foreground",
                table: "Products",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "ProductImages",
                nullable: false,
                defaultValue: new byte[] {  });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Background",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Foreground",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ProductImages");
        }
    }
}
