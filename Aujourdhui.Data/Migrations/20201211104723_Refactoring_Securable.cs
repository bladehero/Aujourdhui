using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aujourdhui.Data.Migrations
{
    public partial class Refactoring_Securable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0", "73290077-8323-4011-93c8-018b07e57244" });

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PortionTypes",
                keyColumn: "PortionType",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "PortionTypes",
                keyColumn: "PortionType",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PortionTypes",
                keyColumn: "PortionType",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RecipeDifficultyLevels",
                keyColumn: "RecipeDifficultyLevel",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "RecipeDifficultyLevels",
                keyColumn: "RecipeDifficultyLevel",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeDifficultyLevels",
                keyColumn: "RecipeDifficultyLevel",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RecipeDifficultyLevels",
                keyColumn: "RecipeDifficultyLevel",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RecipeDifficultyLevels",
                keyColumn: "RecipeDifficultyLevel",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RecipeItemTypes",
                keyColumn: "RecipeItemType",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "RecipeItemTypes",
                keyColumn: "RecipeItemType",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeItemTypes",
                keyColumn: "RecipeItemType",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73290077-8323-4011-93c8-018b07e57244");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "RecipeItemTypes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "RecipeDifficultyLevels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "PortionTypes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Languages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "AspNetUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RecipeItemTypes_Guid",
                table: "RecipeItemTypes",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RecipeDifficultyLevels_Guid",
                table: "RecipeDifficultyLevels",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PortionTypes_Guid",
                table: "PortionTypes",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Languages_Guid",
                table: "Languages",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_Guid",
                table: "AspNetUsers",
                column: "Guid");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "1dcf16e2-ac56-48a3-a8c2-bb3945f469ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e8d15aa5-7685-4e27-b62d-5a2a91f285c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "229a01b1-42c1-48aa-92f4-dccb670ce60d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "968139af-1b73-44f9-982a-ead2190e6958");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Guid", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "953049a0-6d8e-47e8-8ffe-6b0fb7ce0851", 0, "141e6369-931f-47f5-a80e-e6763ef3cbc5", "nikita.dermenzhi@gmail.com", true, "Nikita", new Guid("97923f0c-02c2-4b05-8dde-4abdeab339a8"), "Dermenzhi", false, null, "A.", "NIKITA.DERMENZHI@GMAIL.COM", "MASTER", "AQAAAAEAACcQAAAAEKwbP/Yqsn15/KK2CkUjvqW6N6rYjDeynkFUtya+K7Si5pzQBVlI150fVy4225PKvw==", "+380687379427", true, "80846e7e-ac21-485a-9bc9-426c7007b205", false, "master" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Language", "Code", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, "ru", new Guid("24b36a41-0b64-4561-b4bf-c8543488ab4a"), "Russian" },
                    { 0, "en", new Guid("d6c05bb7-a827-4264-a6cb-9746b01f492f"), "English" }
                });

            migrationBuilder.InsertData(
                table: "PortionTypes",
                columns: new[] { "PortionType", "Guid", "Name", "Units" },
                values: new object[,]
                {
                    { 0, new Guid("6dc12895-511c-4dae-9dd2-c4ad38a053b9"), "Pieces", "pcs." },
                    { 1, new Guid("86de84e4-629b-4b8b-8442-a0feef48b201"), "Volumetric", "ml." },
                    { 2, new Guid("36ada2d4-a683-49ff-96d0-fe55474815a7"), "Weight", "g." }
                });

            migrationBuilder.InsertData(
                table: "RecipeDifficultyLevels",
                columns: new[] { "RecipeDifficultyLevel", "Description", "Guid", "Name" },
                values: new object[,]
                {
                    { 4, "A perfect knowledge of the topic and a daily professional usage", new Guid("d61c6921-87cc-47cd-a8f1-c7e28e796913"), "Expert" },
                    { 2, "A basic knowledge of the topic but no regular professional usage", new Guid("51556e81-cd51-4261-b703-423256e15d05"), "Intermediate" },
                    { 1, "A very basic knowledge of the topic but no professional usage", new Guid("8ed302bc-057a-48a2-a168-6b7f72b8c9d7"), "Basic" },
                    { 0, "No knowledge at all of the topic", new Guid("b4e85296-5d35-4e87-9da0-e4e810077bb8"), "Beginner" },
                    { 3, "A good knowledge of the topic and a regular professional usage", new Guid("81800190-482c-4e89-8a12-ec11618e113e"), "Advanced" }
                });

            migrationBuilder.InsertData(
                table: "RecipeItemTypes",
                columns: new[] { "RecipeItemType", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("9a4c35e8-4e00-4c93-ab53-b4178514cbb7"), "Header" },
                    { 0, new Guid("b850850b-c09e-4b08-80fc-0a3b3e62edcf"), "Paragraph" },
                    { 2, new Guid("fe011dd6-00a7-45ab-b91d-8dc30327b670"), "Image" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0", "953049a0-6d8e-47e8-8ffe-6b0fb7ce0851" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_RecipeItemTypes_Guid",
                table: "RecipeItemTypes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RecipeDifficultyLevels_Guid",
                table: "RecipeDifficultyLevels");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PortionTypes_Guid",
                table: "PortionTypes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Languages_Guid",
                table: "Languages");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_Guid",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0", "953049a0-6d8e-47e8-8ffe-6b0fb7ce0851" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "953049a0-6d8e-47e8-8ffe-6b0fb7ce0851");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "RecipeItemTypes");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "RecipeDifficultyLevels");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "PortionTypes");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "0ce286ff-6e0d-4a63-8313-3af05c127bc0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6a591e9d-3b59-42c3-947d-dccaad65cbe8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "65a3f8b0-469f-402e-9c71-f3291ece3289");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "c9a512bc-e4e4-46bf-8a9a-f6e86aa64194");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "73290077-8323-4011-93c8-018b07e57244", 0, "b2491bcb-4242-4b49-b18c-01d8dc6adb2c", "nikita.dermenzhi@gmail.com", true, "Nikita", "Dermenzhi", false, null, "A.", "NIKITA.DERMENZHI@GMAIL.COM", "MASTER", "AQAAAAEAACcQAAAAEGtTm0hhHobwhP1O0W0azBTqh5y/xBNYAr5+cuUIUFV4FHbV4oYBZ2z+sFKyeqrHOQ==", "+380687379427", true, "87d1bcf6-bf21-4fbb-bb59-297e74f1d0ad", false, "master" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0", "73290077-8323-4011-93c8-018b07e57244" });
        }
    }
}
