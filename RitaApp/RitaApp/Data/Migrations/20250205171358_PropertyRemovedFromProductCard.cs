﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RitaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class PropertyRemovedFromProductCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductCards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductCards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
