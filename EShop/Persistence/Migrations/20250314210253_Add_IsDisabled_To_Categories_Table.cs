﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_IsDisabled_To_Categories_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Categories");
        }
    }
}
