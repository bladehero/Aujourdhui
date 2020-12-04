using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Aujourdhui.Data.Migrations
{
    public partial class Initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ParentID = table.Column<int>(type: "integer", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Expiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Data = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "ImageReferences",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Table = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ObjectId = table.Column<int>(type: "integer", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageReferences", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Expiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Data = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "PortionTypes",
                columns: table => new
                {
                    PortionType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Units = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortionTypes", x => x.PortionType);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDifficultyLevels",
                columns: table => new
                {
                    RecipeDifficultyLevel = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDifficultyLevels", x => x.RecipeDifficultyLevel);
                });

            migrationBuilder.CreateTable(
                name: "RecipeItemTypes",
                columns: table => new
                {
                    RecipeItemType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeItemTypes", x => x.RecipeItemType);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Firms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Firms_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Firms_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    EstimatedPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Group_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Options_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Options_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Properties_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
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
                    EstimationCost = table.Column<decimal>(type: "numeric", nullable: true),
                    FirmID = table.Column<int>(type: "integer", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ingredients_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredients_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredients_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Firms_FirmID",
                        column: x => x.FirmID,
                        principalTable: "Firms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EstimatedPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    RecipeDifficultyLevel = table.Column<int>(type: "integer", nullable: true),
                    GroupID = table.Column<int>(type: "integer", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recipes_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeDifficultyLevels_RecipeDifficultyLevel",
                        column: x => x.RecipeDifficultyLevel,
                        principalTable: "RecipeDifficultyLevels",
                        principalColumn: "RecipeDifficultyLevel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasedIngredients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateProduced = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DateExpiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Cost = table.Column<double>(type: "double precision", nullable: false),
                    Portion = table.Column<double>(type: "double precision", nullable: false),
                    PortionType = table.Column<int>(type: "integer", nullable: false),
                    IngredientID = table.Column<int>(type: "integer", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesID = table.Column<int>(type: "integer", nullable: false),
                    ProductsID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesID, x.ProductsID });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesID",
                        column: x => x.CategoriesID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProperty",
                columns: table => new
                {
                    ProductsID = table.Column<int>(type: "integer", nullable: false),
                    PropertiesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProperty", x => new { x.ProductsID, x.PropertiesID });
                    table.ForeignKey(
                        name: "FK_ProductProperty_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProperty_Properties_PropertiesID",
                        column: x => x.PropertiesID,
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    OldPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Specifications_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Specifications_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Specifications_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: true),
                    DurationInMinutes = table.Column<int>(type: "integer", nullable: true),
                    RecipeItemType = table.Column<int>(type: "integer", nullable: false),
                    RecipeID = table.Column<int>(type: "integer", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecipeItems_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeItems_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeItems_RecipeItemTypes_RecipeItemType",
                        column: x => x.RecipeItemType,
                        principalTable: "RecipeItemTypes",
                        principalColumn: "RecipeItemType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeItems_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PricePolicies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpecificationID = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricePolicies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PricePolicies_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PricePolicies_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PricePolicies_Specifications_SpecificationID",
                        column: x => x.SpecificationID,
                        principalTable: "Specifications",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationOptions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpecificationID = table.Column<int>(type: "integer", nullable: true),
                    OptionID = table.Column<int>(type: "integer", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationOptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpecificationOptions_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecificationOptions_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecificationOptions_Options_OptionID",
                        column: x => x.OptionID,
                        principalTable: "Options",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificationOptions_Specifications_SpecificationID",
                        column: x => x.SpecificationID,
                        principalTable: "Specifications",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeItemIngredients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true),
                    RecipeItemID = table.Column<int>(type: "integer", nullable: false),
                    IngredientID = table.Column<int>(type: "integer", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserID = table.Column<string>(type: "text", nullable: false),
                    ModifiedByUserID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeItemIngredients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecipeItemIngredients_AspNetUsers_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeItemIngredients_AspNetUsers_ModifiedByUserID",
                        column: x => x.ModifiedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeItemIngredients_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeItemIngredients_RecipeItems_RecipeItemID",
                        column: x => x.RecipeItemID,
                        principalTable: "RecipeItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PortionTypes",
                columns: new[] { "PortionType", "Name", "Units" },
                values: new object[,]
                {
                    { 0, "Pieces", "pcs." },
                    { 1, "Volumetric", "ml." },
                    { 2, "Weight", "g." }
                });

            migrationBuilder.InsertData(
                table: "RecipeDifficultyLevels",
                columns: new[] { "RecipeDifficultyLevel", "Description", "Name" },
                values: new object[,]
                {
                    { 0, "No knowledge at all of the topic", "Beginner" },
                    { 1, "A very basic knowledge of the topic but no professional usage", "Basic" },
                    { 2, "A basic knowledge of the topic but no regular professional usage", "Intermediate" },
                    { 3, "A good knowledge of the topic and a regular professional usage", "Advanced" },
                    { 4, "A perfect knowledge of the topic and a daily professional usage", "Expert" }
                });

            migrationBuilder.InsertData(
                table: "RecipeItemTypes",
                columns: new[] { "RecipeItemType", "Name" },
                values: new object[,]
                {
                    { 0, "Paragraph" },
                    { 1, "Header" },
                    { 2, "Image" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentID",
                table: "Categories",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsID",
                table: "CategoryProduct",
                column: "ProductsID");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_CreatedByUserID",
                table: "Firms",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_ModifiedByUserID",
                table: "Firms",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Group_CreatedByUserID",
                table: "Group",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Group_ModifiedByUserID",
                table: "Group",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_CreatedByUserID",
                table: "Ingredients",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_FirmID",
                table: "Ingredients",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_ModifiedByUserID",
                table: "Ingredients",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Options_CreatedByUserID",
                table: "Options",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ModifiedByUserID",
                table: "Options",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PricePolicies_CreatedByUserID",
                table: "PricePolicies",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PricePolicies_ModifiedByUserID",
                table: "PricePolicies",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PricePolicies_SpecificationID",
                table: "PricePolicies",
                column: "SpecificationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperty_PropertiesID",
                table: "ProductProperty",
                column: "PropertiesID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedByUserID",
                table: "Products",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FirmID",
                table: "Products",
                column: "FirmID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModifiedByUserID",
                table: "Products",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CreatedByUserID",
                table: "Properties",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ModifiedByUserID",
                table: "Properties",
                column: "ModifiedByUserID");

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

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItemIngredients_CreatedByUserID",
                table: "RecipeItemIngredients",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItemIngredients_IngredientID",
                table: "RecipeItemIngredients",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItemIngredients_ModifiedByUserID",
                table: "RecipeItemIngredients",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItemIngredients_RecipeItemID",
                table: "RecipeItemIngredients",
                column: "RecipeItemID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItems_CreatedByUserID",
                table: "RecipeItems",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItems_ModifiedByUserID",
                table: "RecipeItems",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItems_RecipeID",
                table: "RecipeItems",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItems_RecipeItemType",
                table: "RecipeItems",
                column: "RecipeItemType");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CreatedByUserID",
                table: "Recipes",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_GroupID",
                table: "Recipes",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ModifiedByUserID",
                table: "Recipes",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeDifficultyLevel",
                table: "Recipes",
                column: "RecipeDifficultyLevel");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationOptions_CreatedByUserID",
                table: "SpecificationOptions",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationOptions_ModifiedByUserID",
                table: "SpecificationOptions",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationOptions_OptionID",
                table: "SpecificationOptions",
                column: "OptionID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationOptions_SpecificationID",
                table: "SpecificationOptions",
                column: "SpecificationID");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_CreatedByUserID",
                table: "Specifications",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_ModifiedByUserID",
                table: "Specifications",
                column: "ModifiedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_ProductID",
                table: "Specifications",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "ImageReferences");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "PricePolicies");

            migrationBuilder.DropTable(
                name: "ProductProperty");

            migrationBuilder.DropTable(
                name: "PurchasedIngredients");

            migrationBuilder.DropTable(
                name: "RecipeItemIngredients");

            migrationBuilder.DropTable(
                name: "SpecificationOptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "PortionTypes");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "RecipeItems");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "RecipeItemTypes");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "RecipeDifficultyLevels");

            migrationBuilder.DropTable(
                name: "Firms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
