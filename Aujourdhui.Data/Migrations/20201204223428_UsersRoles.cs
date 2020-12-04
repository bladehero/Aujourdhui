using Microsoft.EntityFrameworkCore.Migrations;

namespace Aujourdhui.Data.Migrations
{
    public partial class UsersRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0", "98fb26d6-e13d-4bad-9bce-abb0e03c2dec", "Master", "MASTER" },
                    { "1", "6fee59c2-937f-427b-b88a-cdd3b102d53a", "Admin", "ADMIN" },
                    { "2", "3e72134b-aaa4-4057-85a3-69287255ddf8", "Moderator", "MODERATOR" },
                    { "3", "7db693a6-b219-4194-b672-3a9bdb1e7fe9", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2644ae72-2070-4484-b4d8-79b56b1dacd9", 0, "159cf06a-a39d-4082-83e8-ca4674e44e0a", "nikita.dermenzhi@gmail.com", true, "Nikita", "Dermenzhi", false, null, "A.", "NIKITA.DERMENZHI@GMAIL.COM", "MASTER", "AQAAAAEAACcQAAAAEEpBaoBcZrzp9ueq31Zh6gaIPRo9KuHDDsoe9FeX9RuOJwitbslFvbse43/y2Ylssg==", "+380687379427", true, "977b40b9-9d11-4c48-85c9-d00fc2fa7c62", false, "master" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0", "2644ae72-2070-4484-b4d8-79b56b1dacd9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0", "2644ae72-2070-4484-b4d8-79b56b1dacd9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2644ae72-2070-4484-b4d8-79b56b1dacd9");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Categories");
        }
    }
}
