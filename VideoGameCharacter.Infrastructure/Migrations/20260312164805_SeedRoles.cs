using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameCharacter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a",
                column: "ConcurrencyStamp",
                value: "6f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a",
                column: "ConcurrencyStamp",
                value: "7f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0h", "AQAAAAIAAYagAAAAEAfTkxvr0sgR0Zdqh6VMeoLzMc4DzP7G3j0eLr7H5nZYAIPiCydjgeZsP2rg8H0Ksw==", "8f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0g" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a",
                column: "ConcurrencyStamp",
                value: "0d460c2f-076c-41e0-8353-f4c8666893a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a",
                column: "ConcurrencyStamp",
                value: "75aa4a0e-70e2-4a3c-b404-9fc35926bf49");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f0e34c9-b7b2-4d5e-8e8e-8a0a9a0a9a0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb37b076-f9c1-4e8e-8b30-3e1951adb147", "AQAAAAIAAYagAAAAEE1yHo4PKDlZPGC62x3WooDC7rJI2r2djPL0CYWz6E/Ynd5+17kws6JLI8HCuOXNyA==", "32bd35a6-b526-4e4d-8601-cedb6587bb7c" });
        }
    }
}
