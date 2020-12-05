using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Aujourdhui.Data.Migrations
{
    public partial class StorageRecipeProductExtensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_AspNetUsers_CreatedByUserID",
                table: "Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Content_AspNetUsers_ModifiedByUserID",
                table: "Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Content_LanguageValue_Language",
                table: "Content");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryLanguageValue_LanguageValue_LanguagesLanguage",
                table: "CountryLanguageValue");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Firms_FirmID",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageKey_Key_KeyID",
                table: "LanguageKey");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageKey_LanguageValue_Language",
                table: "LanguageKey");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_AspNetUsers_CreatedByUserID",
                table: "Translation");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_AspNetUsers_ModifiedByUserID",
                table: "Translation");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Content_ContentID",
                table: "Translation");

            migrationBuilder.DropForeignKey(
                name: "FK_Translation_LanguageValue_Language",
                table: "Translation");

            migrationBuilder.DropTable(
                name: "PurchasedIngredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_FirmID",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translation",
                table: "Translation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageValue",
                table: "LanguageValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageKey",
                table: "LanguageKey");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Key",
                table: "Key");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Content",
                table: "Content");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0", "9c4d44a3-fc49-4ae7-a6c2-4a182459c6a9" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c4d44a3-fc49-4ae7-a6c2-4a182459c6a9");

            migrationBuilder.DropColumn(
                name: "FirmID",
                table: "Ingredients");

            migrationBuilder.RenameTable(
                name: "Translation",
                newName: "Translations");

            migrationBuilder.RenameTable(
                name: "LanguageValue",
                newName: "Languages");

            migrationBuilder.RenameTable(
                name: "LanguageKey",
                newName: "LanguageKeys");

            migrationBuilder.RenameTable(
                name: "Key",
                newName: "Keys");

            migrationBuilder.RenameTable(
                name: "Content",
                newName: "Contents");

            migrationBuilder.RenameIndex(
                name: "IX_Translation_ModifiedByUserID",
                table: "Translations",
                newName: "IX_Translations_ModifiedByUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Translation_Language",
                table: "Translations",
                newName: "IX_Translations_Language");

            migrationBuilder.RenameIndex(
                name: "IX_Translation_CreatedByUserID",
                table: "Translations",
                newName: "IX_Translations_CreatedByUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Translation_ContentID",
                table: "Translations",
                newName: "IX_Translations_ContentID");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageKey_Language",
                table: "LanguageKeys",
                newName: "IX_LanguageKeys_Language");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageKey_KeyID",
                table: "LanguageKeys",
                newName: "IX_LanguageKeys_KeyID");

            migrationBuilder.RenameIndex(
                name: "IX_Content_ModifiedByUserID",
                table: "Contents",
                newName: "IX_Contents_ModifiedByUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Content_Language",
                table: "Contents",
                newName: "IX_Contents_Language");

            migrationBuilder.RenameIndex(
                name: "IX_Content_CreatedByUserID",
                table: "Contents",
                newName: "IX_Contents_CreatedByUserID");

            migrationBuilder.AddColumn<int>(
                name: "ExpirationInDays",
                table: "Recipes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReleasedRecipeID",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translations",
                table: "Translations",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Language");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageKeys",
                table: "LanguageKeys",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Keys",
                table: "Keys",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contents",
                table: "Contents",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Commodities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ExpirationInDays = table.Column<int>(type: "integer", nullable: false),
                    Protein = table.Column<double>(type: "double precision", nullable: false),
                    Fat = table.Column<double>(type: "double precision", nullable: false),
                    Carbohydrates = table.Column<double>(type: "double precision", nullable: false),
                    Alcohol = table.Column<double>(type: "double precision", nullable: false),
                    Calories = table.Column<double>(type: "double precision", nullable: false),
                    FirmID = table.Column<int>(type: "integer", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Commodities_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commodities_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commodities_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientRecipe",
                columns: table => new
                {
                    IngredientsID = table.Column<int>(type: "integer", nullable: false),
                    RecipesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientRecipe", x => new { x.IngredientsID, x.RecipesID });
                    table.ForeignKey(
                        name: "FK_IngredientRecipe_Ingredients_IngredientsID",
                        column: x => x.IngredientsID,
                        principalTable: "Ingredients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientRecipe_Recipes_RecipesID",
                        column: x => x.RecipesID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReleasedRecipes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecipeID = table.Column<int>(type: "integer", nullable: false),
                    Released = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleasedRecipes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReleasedRecipes_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReleasedRecipes_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReleasedRecipes_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommodityIngredient",
                columns: table => new
                {
                    CommoditiesID = table.Column<int>(type: "integer", nullable: false),
                    IngredientsID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityIngredient", x => new { x.CommoditiesID, x.IngredientsID });
                    table.ForeignKey(
                        name: "FK_CommodityIngredient_Commodities_CommoditiesID",
                        column: x => x.CommoditiesID,
                        principalTable: "Commodities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommodityIngredient_Ingredients_IngredientsID",
                        column: x => x.IngredientsID,
                        principalTable: "Ingredients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommodityLinks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: false),
                    CommodityID = table.Column<int>(type: "integer", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityLinks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommodityLinks_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommodityLinks_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommodityLinks_Commodities_CommodityID",
                        column: x => x.CommodityID,
                        principalTable: "Commodities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateProduced = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DateExpiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Cost = table.Column<double>(type: "double precision", nullable: false),
                    Portion = table.Column<double>(type: "double precision", nullable: false),
                    PortionType = table.Column<int>(type: "integer", nullable: false),
                    CommodityID = table.Column<int>(type: "integer", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Purchases_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Commodities_CommodityID",
                        column: x => x.CommodityID,
                        principalTable: "Commodities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_PortionTypes_PortionType",
                        column: x => x.PortionType,
                        principalTable: "PortionTypes",
                        principalColumn: "PortionType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseConsumptions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PurchaseID = table.Column<int>(type: "integer", nullable: false),
                    ReleasedRecipeID = table.Column<int>(type: "integer", nullable: true),
                    Consumption = table.Column<double>(type: "double precision", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseConsumptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseConsumptions_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseConsumptions_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseConsumptions_Purchases_PurchaseID",
                        column: x => x.PurchaseID,
                        principalTable: "Purchases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseConsumptions_ReleasedRecipes_ReleasedRecipeID",
                        column: x => x.ReleasedRecipeID,
                        principalTable: "ReleasedRecipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_ReleasedRecipeID",
                table: "Products",
                column: "ReleasedRecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_CreatedByUserID",
                table: "Commodities",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_FirmID",
                table: "Commodities",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_ModifiedByUserID",
                table: "Commodities",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CommodityIngredient_IngredientsID",
                table: "CommodityIngredient",
                column: "IngredientsID");

            migrationBuilder.CreateIndex(
                name: "IX_CommodityLinks_CommodityID",
                table: "CommodityLinks",
                column: "CommodityID");

            migrationBuilder.CreateIndex(
                name: "IX_CommodityLinks_CreatedByUserID",
                table: "CommodityLinks",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CommodityLinks_ModifiedByUserID",
                table: "CommodityLinks",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientRecipe_RecipesID",
                table: "IngredientRecipe",
                column: "RecipesID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseConsumptions_CreatedByUserID",
                table: "PurchaseConsumptions",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseConsumptions_ModifiedByUserID",
                table: "PurchaseConsumptions",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseConsumptions_PurchaseID",
                table: "PurchaseConsumptions",
                column: "PurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseConsumptions_ReleasedRecipeID",
                table: "PurchaseConsumptions",
                column: "ReleasedRecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CommodityID",
                table: "Purchases",
                column: "CommodityID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CreatedByUserID",
                table: "Purchases",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ModifiedByUserID",
                table: "Purchases",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PortionType",
                table: "Purchases",
                column: "PortionType");

            migrationBuilder.CreateIndex(
                name: "IX_ReleasedRecipes_CreatedByUserID",
                table: "ReleasedRecipes",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ReleasedRecipes_ModifiedByUserID",
                table: "ReleasedRecipes",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ReleasedRecipes_RecipeID",
                table: "ReleasedRecipes",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_AspNetUsers_CreatedByUserID",
                table: "Contents",
                column: "CreatedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_AspNetUsers_ModifiedByUserID",
                table: "Contents",
                column: "ModifiedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Languages_Language",
                table: "Contents",
                column: "Language",
                principalTable: "Languages",
                principalColumn: "Language",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryLanguageValue_Languages_LanguagesLanguage",
                table: "CountryLanguageValue",
                column: "LanguagesLanguage",
                principalTable: "Languages",
                principalColumn: "Language",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageKeys_Keys_KeyID",
                table: "LanguageKeys",
                column: "KeyID",
                principalTable: "Keys",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageKeys_Languages_Language",
                table: "LanguageKeys",
                column: "Language",
                principalTable: "Languages",
                principalColumn: "Language",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ReleasedRecipes_ReleasedRecipeID",
                table: "Products",
                column: "ReleasedRecipeID",
                principalTable: "ReleasedRecipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_AspNetUsers_CreatedByUserID",
                table: "Translations",
                column: "CreatedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_AspNetUsers_ModifiedByUserID",
                table: "Translations",
                column: "ModifiedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Contents_ContentID",
                table: "Translations",
                column: "ContentID",
                principalTable: "Contents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Languages_Language",
                table: "Translations",
                column: "Language",
                principalTable: "Languages",
                principalColumn: "Language",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_AspNetUsers_CreatedByUserID",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_AspNetUsers_ModifiedByUserID",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Languages_Language",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryLanguageValue_Languages_LanguagesLanguage",
                table: "CountryLanguageValue");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageKeys_Keys_KeyID",
                table: "LanguageKeys");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageKeys_Languages_Language",
                table: "LanguageKeys");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ReleasedRecipes_ReleasedRecipeID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_AspNetUsers_CreatedByUserID",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_AspNetUsers_ModifiedByUserID",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Contents_ContentID",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Languages_Language",
                table: "Translations");

            migrationBuilder.DropTable(
                name: "CommodityIngredient");

            migrationBuilder.DropTable(
                name: "CommodityLinks");

            migrationBuilder.DropTable(
                name: "IngredientRecipe");

            migrationBuilder.DropTable(
                name: "PurchaseConsumptions");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "ReleasedRecipes");

            migrationBuilder.DropTable(
                name: "Commodities");

            migrationBuilder.DropIndex(
                name: "IX_Products_ReleasedRecipeID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translations",
                table: "Translations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageKeys",
                table: "LanguageKeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Keys",
                table: "Keys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contents",
                table: "Contents");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0", "4fc63cc8-edcd-423a-a351-a94b114e1b41" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fc63cc8-edcd-423a-a351-a94b114e1b41");

            migrationBuilder.DropColumn(
                name: "ExpirationInDays",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ReleasedRecipeID",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Translations",
                newName: "Translation");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "LanguageValue");

            migrationBuilder.RenameTable(
                name: "LanguageKeys",
                newName: "LanguageKey");

            migrationBuilder.RenameTable(
                name: "Keys",
                newName: "Key");

            migrationBuilder.RenameTable(
                name: "Contents",
                newName: "Content");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_ModifiedByUserID",
                table: "Translation",
                newName: "IX_Translation_ModifiedByUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_Language",
                table: "Translation",
                newName: "IX_Translation_Language");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_CreatedByUserID",
                table: "Translation",
                newName: "IX_Translation_CreatedByUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Translations_ContentID",
                table: "Translation",
                newName: "IX_Translation_ContentID");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageKeys_Language",
                table: "LanguageKey",
                newName: "IX_LanguageKey_Language");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageKeys_KeyID",
                table: "LanguageKey",
                newName: "IX_LanguageKey_KeyID");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_ModifiedByUserID",
                table: "Content",
                newName: "IX_Content_ModifiedByUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_Language",
                table: "Content",
                newName: "IX_Content_Language");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_CreatedByUserID",
                table: "Content",
                newName: "IX_Content_CreatedByUserID");

            migrationBuilder.AddColumn<int>(
                name: "FirmID",
                table: "Ingredients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translation",
                table: "Translation",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageValue",
                table: "LanguageValue",
                column: "Language");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageKey",
                table: "LanguageKey",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Key",
                table: "Key",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Content",
                table: "Content",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "PurchasedIngredients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cost = table.Column<double>(type: "double precision", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateExpiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateProduced = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientID = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false),
                    Portion = table.Column<double>(type: "double precision", nullable: false),
                    PortionType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedIngredients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchasedIngredients_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasedIngredients_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasedIngredients_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasedIngredients_PortionTypes_PortionType",
                        column: x => x.PortionType,
                        principalTable: "PortionTypes",
                        principalColumn: "PortionType",
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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0", "9c4d44a3-fc49-4ae7-a6c2-4a182459c6a9" });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_FirmID",
                table: "Ingredients",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedIngredients_CreatedByUserID",
                table: "PurchasedIngredients",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedIngredients_IngredientID",
                table: "PurchasedIngredients",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedIngredients_ModifiedByUserID",
                table: "PurchasedIngredients",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedIngredients_PortionType",
                table: "PurchasedIngredients",
                column: "PortionType");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_AspNetUsers_CreatedByUserID",
                table: "Content",
                column: "CreatedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Content_AspNetUsers_ModifiedByUserID",
                table: "Content",
                column: "ModifiedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Content_LanguageValue_Language",
                table: "Content",
                column: "Language",
                principalTable: "LanguageValue",
                principalColumn: "Language",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryLanguageValue_LanguageValue_LanguagesLanguage",
                table: "CountryLanguageValue",
                column: "LanguagesLanguage",
                principalTable: "LanguageValue",
                principalColumn: "Language",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Firms_FirmID",
                table: "Ingredients",
                column: "FirmID",
                principalTable: "Firms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageKey_Key_KeyID",
                table: "LanguageKey",
                column: "KeyID",
                principalTable: "Key",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageKey_LanguageValue_Language",
                table: "LanguageKey",
                column: "Language",
                principalTable: "LanguageValue",
                principalColumn: "Language",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_AspNetUsers_CreatedByUserID",
                table: "Translation",
                column: "CreatedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_AspNetUsers_ModifiedByUserID",
                table: "Translation",
                column: "ModifiedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Content_ContentID",
                table: "Translation",
                column: "ContentID",
                principalTable: "Content",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_LanguageValue_Language",
                table: "Translation",
                column: "Language",
                principalTable: "LanguageValue",
                principalColumn: "Language",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
