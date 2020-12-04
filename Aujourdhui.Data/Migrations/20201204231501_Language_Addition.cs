using Microsoft.EntityFrameworkCore.Migrations;

namespace Aujourdhui.Data.Migrations
{
    public partial class Language_Addition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0", "b46ad132-6c54-469b-a0a6-c8292183fdc0" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b46ad132-6c54-469b-a0a6-c8292183fdc0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "2dfd135f-d3fa-4727-8f7b-0e4ec85d9430");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7257adfd-9827-4204-85dc-814ed48ef8a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b948092b-a926-477d-b488-1dc2d1e3f146");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "2c6ae2e3-9f05-4a2f-a46c-d4c4101e5eba");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f63d8a6b-7b57-4cc1-a20c-96bec4c77562", 0, "fd5c7eb3-5998-4d7b-bbf3-b799cbdc7b14", "nikita.dermenzhi@gmail.com", true, "Nikita", "Dermenzhi", false, null, "A.", "NIKITA.DERMENZHI@GMAIL.COM", "MASTER", "AQAAAAEAACcQAAAAEMfCuV8+8gDV1N8vKn/N3mjvnepzti+Y531xDyqomvnwwj+6QNEIypQn0l/3JXYB/g==", "+380687379427", true, "fac5900d-75e9-402a-90d2-47e8fd9aae34", false, "master" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0", "f63d8a6b-7b57-4cc1-a20c-96bec4c77562" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0", "f63d8a6b-7b57-4cc1-a20c-96bec4c77562" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f63d8a6b-7b57-4cc1-a20c-96bec4c77562");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "16dfc827-f3d9-473e-b329-026b8a04bd36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a7b0c48e-a88c-40c5-9148-ae7c5381d35f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "c5bfb95d-1b63-4463-bcf4-aa9d8a2f20ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "2171a406-d30a-461e-bb4d-1ade9040aeac");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b46ad132-6c54-469b-a0a6-c8292183fdc0", 0, "a848cb1f-9b65-4d22-b9ef-294a3a67cf0c", "nikita.dermenzhi@gmail.com", true, "Nikita", "Dermenzhi", false, null, "A.", "NIKITA.DERMENZHI@GMAIL.COM", "MASTER", "AQAAAAEAACcQAAAAEDIRHglRZGY9Uyeb0Asn3iKxS6YhBFQ4PyGDMiMDWrf1a+pBfW4eXnKvmJHV/abemw==", "+380687379427", true, "a805bb21-11e5-4f89-8456-232409a84085", false, "master" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0", "b46ad132-6c54-469b-a0a6-c8292183fdc0" });
        }
    }
}
