using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Seeding_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefault", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01957b56-0791-7fb2-846a-d59db7d302f8"), "CC0B5346-F8AD-4580-8B6C-E88F70D2A493", false, false, "Admin", "ADMIN" },
                    { new Guid("01957b56-0791-7fb2-846a-d59ed8104780"), "9ADD3A9D-00D3-42DF-83FD-E8FAA10CA3DD", true, false, "Client", "CLIENT" },
                    { new Guid("01957b56-0791-7fb2-846a-d59f359f3426"), "76CE33FE-E990-4DF4-A4B0-712609EE0A62", false, false, "Seller", "SELLER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "IsDisabled", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("01957b40-a60a-7413-ae16-6c4727049ca9"), 0, "283AEB14-CE9F-4AE0-88F9-4C86FCEFA221", new DateTime(2025, 3, 9, 21, 38, 54, 579, DateTimeKind.Utc).AddTicks(1943), "admin@eshop.com", true, false, false, null, "ADMIN@ESHOP.COM", "ADMIN_NAME", "AQAAAAIAAYagAAAAECmR5YUNa+8lm4NNTA5ONhy0jRto2LT7XAmS+CBwFwJ4Z6F5+4erVz4AVQ0ZLuC/fg==", null, false, "", "96ADA591-B04C-4D37-B57B-9FCBA8262C5B", false, "Admin_Name" },
                    { new Guid("01957b40-a60b-780d-b328-f9bf9c4aa691"), 0, "303BE4AC-8A47-4B2F-91F2-2BB1B459470D", new DateTime(2025, 3, 9, 21, 38, 54, 580, DateTimeKind.Utc).AddTicks(3798), "client@test.com", true, false, false, null, "CLIENT@TEST.COM", "CLIENT_NAME", "AQAAAAIAAYagAAAAEMie4u7ffTRAMN7ZbSrikIwbANJmNMC/1n4oBXgFcrSo32sL0xcUG75XenUMNGFCig==", null, false, "", "19439CAF-856D-46A7-9903-6141810F446B", false, "Client_Name" },
                    { new Guid("01957b40-a60b-780d-b328-f9c0cd4b0d85"), 0, "1238F62D-0C73-4298-B0B5-F85FDFE9CDBB", new DateTime(2025, 3, 9, 21, 38, 54, 580, DateTimeKind.Utc).AddTicks(3848), "seller@test.com", true, false, false, null, "SELLER@TEST.COM", "SELLER_NAME", "AQAAAAIAAYagAAAAEEgeAgFomAVkZC8mbMWMscDo/z55UzNa4DfNUGSOlMThA2y5+JxkICCpDvnPH1Tp0A==", null, false, "", "B99E64F4-E3AC-449E-843D-5CC67A1FCAFF", false, "Seller_Name" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permissions", "product:add", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 2, "Permissions", "product:update", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 3, "Permissions", "product:delete", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 4, "Permissions", "review:add", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 5, "Permissions", "review:update", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 6, "Permissions", "review:delete", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 7, "Permissions", "users:read", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 8, "Permissions", "users:add", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 9, "Permissions", "users:update", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 10, "Permissions", "roles:read", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 11, "Permissions", "roles:add", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") },
                    { 12, "Permissions", "roles:update", new Guid("01957b56-0791-7fb2-846a-d59db7d302f8") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("01957b56-0791-7fb2-846a-d59db7d302f8"), new Guid("01957b40-a60a-7413-ae16-6c4727049ca9") },
                    { new Guid("01957b56-0791-7fb2-846a-d59ed8104780"), new Guid("01957b40-a60b-780d-b328-f9bf9c4aa691") },
                    { new Guid("01957b56-0791-7fb2-846a-d59f359f3426"), new Guid("01957b40-a60b-780d-b328-f9c0cd4b0d85") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("01957b56-0791-7fb2-846a-d59db7d302f8"), new Guid("01957b40-a60a-7413-ae16-6c4727049ca9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("01957b56-0791-7fb2-846a-d59ed8104780"), new Guid("01957b40-a60b-780d-b328-f9bf9c4aa691") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("01957b56-0791-7fb2-846a-d59f359f3426"), new Guid("01957b40-a60b-780d-b328-f9c0cd4b0d85") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01957b56-0791-7fb2-846a-d59db7d302f8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01957b56-0791-7fb2-846a-d59ed8104780"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01957b56-0791-7fb2-846a-d59f359f3426"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("01957b40-a60a-7413-ae16-6c4727049ca9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("01957b40-a60b-780d-b328-f9bf9c4aa691"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("01957b40-a60b-780d-b328-f9c0cd4b0d85"));
        }
    }
}
