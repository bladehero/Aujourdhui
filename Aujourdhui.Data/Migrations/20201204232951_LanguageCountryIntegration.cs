using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Aujourdhui.Data.Migrations
{
    public partial class LanguageCountryIntegration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0", "f63d8a6b-7b57-4cc1-a20c-96bec4c77562" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f63d8a6b-7b57-4cc1-a20c-96bec4c77562");

            migrationBuilder.CreateTable(
                name: "Key",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Table = table.Column<string>(type: "text", nullable: true),
                    Default = table.Column<string>(type: "text", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Key", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LanguageValue",
                columns: table => new
                {
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageValue", x => x.Language);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Table = table.Column<string>(type: "text", nullable: false),
                    Property = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Content_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Content_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Content_LanguageValue_Language",
                        column: x => x.Language,
                        principalTable: "LanguageValue",
                        principalColumn: "Language",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryLanguageValue",
                columns: table => new
                {
                    CountriesID = table.Column<int>(type: "integer", nullable: false),
                    LanguagesLanguage = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLanguageValue", x => new { x.CountriesID, x.LanguagesLanguage });
                    table.ForeignKey(
                        name: "FK_CountryLanguageValue_Countries_CountriesID",
                        column: x => x.CountriesID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryLanguageValue_LanguageValue_LanguagesLanguage",
                        column: x => x.LanguagesLanguage,
                        principalTable: "LanguageValue",
                        principalColumn: "Language",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageKey",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    KeyID = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageKey", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LanguageKey_Key_KeyID",
                        column: x => x.KeyID,
                        principalTable: "Key",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageKey_LanguageValue_Language",
                        column: x => x.Language,
                        principalTable: "LanguageValue",
                        principalColumn: "Language",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContentID = table.Column<int>(type: "integer", nullable: true),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Translation_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Translation_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Translation_Content_ContentID",
                        column: x => x.ContentID,
                        principalTable: "Content",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Translation_LanguageValue_Language",
                        column: x => x.Language,
                        principalTable: "LanguageValue",
                        principalColumn: "Language",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "31553391-0116-4593-90e2-bc6c3d8dcb36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "71586123-0366-4c55-973a-4fddd60d3645");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "50040214-baa0-4c5c-ad0b-dbacb1a0419a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "d00f2d97-807f-43f7-b9aa-098193fa0edb");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9c4d44a3-fc49-4ae7-a6c2-4a182459c6a9", 0, "57969a76-6e3f-4308-9649-a5f4b6911cda", "nikita.dermenzhi@gmail.com", true, "Nikita", "Dermenzhi", false, null, "A.", "NIKITA.DERMENZHI@GMAIL.COM", "MASTER", "AQAAAAEAACcQAAAAEBJ5V/S37C36ijWQcgyNIsR6+hwqDUJ0FRqSyZ7EAQ8G5cJz7Of0X+TtOu46mxxYZw==", "+380687379427", true, "9fb346d6-d1ba-4e4a-ac23-9dd678b3efb6", false, "master" });

            migrationBuilder.InsertData(
                table: "LanguageValue",
                columns: new[] { "Language", "Code", "Name" },
                values: new object[,]
                {
                    { 0, "en", "English" },
                    { 1, "ru", "Russian" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0", "9c4d44a3-fc49-4ae7-a6c2-4a182459c6a9" });

            migrationBuilder.CreateIndex(
                name: "IX_Content_CreatedByUserID",
                table: "Content",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Content_Language",
                table: "Content",
                column: "Language");

            migrationBuilder.CreateIndex(
                name: "IX_Content_ModifiedByUserID",
                table: "Content",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CountryLanguageValue_LanguagesLanguage",
                table: "CountryLanguageValue",
                column: "LanguagesLanguage");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageKey_KeyID",
                table: "LanguageKey",
                column: "KeyID");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageKey_Language",
                table: "LanguageKey",
                column: "Language");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_ContentID",
                table: "Translation",
                column: "ContentID");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_CreatedByUserID",
                table: "Translation",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_Language",
                table: "Translation",
                column: "Language");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_ModifiedByUserID",
                table: "Translation",
                column: "ModifiedByUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryLanguageValue");

            migrationBuilder.DropTable(
                name: "LanguageKey");

            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropTable(
                name: "Key");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "LanguageValue");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0", "9c4d44a3-fc49-4ae7-a6c2-4a182459c6a9" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c4d44a3-fc49-4ae7-a6c2-4a182459c6a9");

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
    }
}
