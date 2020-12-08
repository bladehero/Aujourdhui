using Microsoft.EntityFrameworkCore.Migrations;

namespace Aujourdhui.Data.Migrations
{
    public partial class ImageReferenceNamingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0", "4fc63cc8-edcd-423a-a351-a94b114e1b41" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fc63cc8-edcd-423a-a351-a94b114e1b41");

            migrationBuilder.RenameColumn(
                name: "Table",
                table: "ImageReferences",
                newName: "Entity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "91201529-634c-4c82-becc-a0660634096c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "28743ea0-1833-466b-82eb-7ceb6342d6b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "43eef281-8ab8-42b4-a467-d02086848985");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "99fd8960-f7c6-4089-80da-dc43779538c3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "aff10895-3c12-411a-81b0-9c768ba52521", 0, "db9f99a3-4097-4ff2-9d6e-389d194eb015", "nikita.dermenzhi@gmail.com", true, "Nikita", "Dermenzhi", false, null, "A.", "NIKITA.DERMENZHI@GMAIL.COM", "MASTER", "AQAAAAEAACcQAAAAEFCkwxQ943jP7lRBFJVptZ1vkSfZ3TGZaZGFcRyoqgbjqXyPj/kjSNi0GqrVFOBUuw==", "+380687379427", true, "f01fe236-3f31-455f-8067-8c1981ad4394", false, "master" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0", "aff10895-3c12-411a-81b0-9c768ba52521" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0", "aff10895-3c12-411a-81b0-9c768ba52521" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aff10895-3c12-411a-81b0-9c768ba52521");

            migrationBuilder.RenameColumn(
                name: "Entity",
                table: "ImageReferences",
                newName: "Table");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "9d73a8a6-5cc7-4c5e-9235-4f03c5e3825f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "51edb8f4-ad55-40d3-ac23-65322280a0b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e5ade1d0-4536-4e7c-9f36-3e4dee367aa9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "e8903d69-2461-4087-b91b-22d829f8ddf9");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4fc63cc8-edcd-423a-a351-a94b114e1b41", 0, "26c09afb-33c2-4c5b-a2d7-58485f0c60dd", "nikita.dermenzhi@gmail.com", true, "Nikita", "Dermenzhi", false, null, "A.", "NIKITA.DERMENZHI@GMAIL.COM", "MASTER", "AQAAAAEAACcQAAAAEEMt20TpsTK2xZXhCCYTSDEUQNSjHjBVdkJSavQ/2rdq3N1v0av4amYnBPdt6+Nr2g==", "+380687379427", true, "86560788-d56b-4b0f-8c57-33a83a69ea5b", false, "master" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0", "4fc63cc8-edcd-423a-a351-a94b114e1b41" });
        }
    }
}
