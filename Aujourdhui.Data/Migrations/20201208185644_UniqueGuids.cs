using Microsoft.EntityFrameworkCore.Migrations;

namespace Aujourdhui.Data.Migrations
{
    public partial class UniqueGuids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0", "b82ac23b-454f-48e3-9fe4-acc0fc5d4e59" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b82ac23b-454f-48e3-9fe4-acc0fc5d4e59");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Translations_Guid",
                table: "Translations",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Specifications_Guid",
                table: "Specifications",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_SpecificationOptions_Guid",
                table: "SpecificationOptions",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ReleasedRecipes_Guid",
                table: "ReleasedRecipes",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Recipes_Guid",
                table: "Recipes",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RecipeItems_Guid",
                table: "RecipeItems",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RecipeItemIngredients_Guid",
                table: "RecipeItemIngredients",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Purchases_Guid",
                table: "Purchases",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PurchaseConsumptions_Guid",
                table: "PurchaseConsumptions",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Properties_Guid",
                table: "Properties",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Products_Guid",
                table: "Products",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PricePolicies_Guid",
                table: "PricePolicies",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Options_Guid",
                table: "Options",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_LanguageKeys_Guid",
                table: "LanguageKeys",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Keys_Guid",
                table: "Keys",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Ingredients_Guid",
                table: "Ingredients",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Group_Guid",
                table: "Group",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Firms_Guid",
                table: "Firms",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_FileReferences_Guid",
                table: "FileReferences",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Countries_Guid",
                table: "Countries",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Contents_Guid",
                table: "Contents",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CommodityLinks_Guid",
                table: "CommodityLinks",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Commodities_Guid",
                table: "Commodities",
                column: "Guid");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Categories_Guid",
                table: "Categories",
                column: "Guid");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Translations_Guid",
                table: "Translations");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Specifications_Guid",
                table: "Specifications");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_SpecificationOptions_Guid",
                table: "SpecificationOptions");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ReleasedRecipes_Guid",
                table: "ReleasedRecipes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Recipes_Guid",
                table: "Recipes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RecipeItems_Guid",
                table: "RecipeItems");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RecipeItemIngredients_Guid",
                table: "RecipeItemIngredients");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Purchases_Guid",
                table: "Purchases");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PurchaseConsumptions_Guid",
                table: "PurchaseConsumptions");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Properties_Guid",
                table: "Properties");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Products_Guid",
                table: "Products");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PricePolicies_Guid",
                table: "PricePolicies");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Options_Guid",
                table: "Options");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_LanguageKeys_Guid",
                table: "LanguageKeys");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Keys_Guid",
                table: "Keys");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Ingredients_Guid",
                table: "Ingredients");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Group_Guid",
                table: "Group");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Firms_Guid",
                table: "Firms");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_FileReferences_Guid",
                table: "FileReferences");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Countries_Guid",
                table: "Countries");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Contents_Guid",
                table: "Contents");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CommodityLinks_Guid",
                table: "CommodityLinks");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Commodities_Guid",
                table: "Commodities");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Categories_Guid",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0", "73290077-8323-4011-93c8-018b07e57244" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73290077-8323-4011-93c8-018b07e57244");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "e63aaf02-f29c-4f94-8452-6c69be6b0b74");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "dfdfebf0-d406-48ac-a1b4-8012333707a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "961deb23-b389-4b24-b679-c1cb5c849453");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "9fc9ab52-a0c3-4651-a565-2f64c850cc0f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b82ac23b-454f-48e3-9fe4-acc0fc5d4e59", 0, "1898a252-e142-4589-8b09-a836e3d8d079", "nikita.dermenzhi@gmail.com", true, "Nikita", "Dermenzhi", false, null, "A.", "NIKITA.DERMENZHI@GMAIL.COM", "MASTER", "AQAAAAEAACcQAAAAEHgKBqdzmq5WqiWmhpkTbkfZ/NML4muWtRQ1x4sw2knfXIfwPXPhJcH2Z9Pe/VYdaQ==", "+380687379427", true, "d3a6dd69-c35e-443b-af6c-e0b93d8ad787", false, "master" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0", "b82ac23b-454f-48e3-9fe4-acc0fc5d4e59" });
        }
    }
}
