﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Namira.Migrations
{
    public partial class addedFieldCategoryIdForModelCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Categories_Categories_CategoryId",
            //    table: "Categories");

            //migrationBuilder.DropIndex(
            //    name: "IX_Categories_CategoryId",
            //    table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
