using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideoGameCharacter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesAndAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a", "0d460c2f-076c-41e0-8353-f4c8666893a0", "Admin", "ADMIN" },
                    { "7f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a", "75aa4a0e-70e2-4a3c-b404-9fc35926bf49", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a", 0, "fb37b076-f9c1-4e8e-8b30-3e1951adb147", "admin@videogame.com", true, false, null, "ADMIN@VIDEOGAME.COM", "ADMIN@VIDEOGAME.COM", "AQAAAAIAAYagAAAAEE1yHo4PKDlZPGC62x3WooDC7rJI2r2djPL0CYWz6E/Ynd5+17kws6JLI8HCuOXNyA==", null, false, "32bd35a6-b526-4e4d-8601-cedb6587bb7c", false, "admin@videogame.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a", "8f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a", "8f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a");
        }
    }
}
