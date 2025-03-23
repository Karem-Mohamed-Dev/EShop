using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_IsDisabled_To_SubCategory_Product_ProductReview_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "SubCategories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "ProductReview",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 17, "Permissions", "subcategories:add", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 18, "Permissions", "subcategories:update", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 19, "Permissions", "subcategories:togglestatus", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "ProductReview");
        }
    }
}
