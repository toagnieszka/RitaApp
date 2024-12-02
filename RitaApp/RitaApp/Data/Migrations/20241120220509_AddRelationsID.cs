using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RitaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationsID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCards_Categories_CategoryId",
                table: "ProductCards");

            migrationBuilder.DropIndex(
                name: "IX_ProductCards_CategoryId",
                table: "ProductCards");

            migrationBuilder.AddColumn<int>(
                name: "ProductCardId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductCardId",
                table: "Categories",
                column: "ProductCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ProductCards_ProductCardId",
                table: "Categories",
                column: "ProductCardId",
                principalTable: "ProductCards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ProductCards_ProductCardId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ProductCardId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProductCardId",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCards_CategoryId",
                table: "ProductCards",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCards_Categories_CategoryId",
                table: "ProductCards",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
