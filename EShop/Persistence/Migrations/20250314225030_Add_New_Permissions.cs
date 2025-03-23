using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_New_Permissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 14, "Permissions", "categories:add", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 15, "Permissions", "categories:update", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 16, "Permissions", "categories:togglestatus", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16);
        }
    }
}
