using Aujourdhui.Data.Models;
using Aujourdhui.Data.Models.Languages;
using Aujourdhui.Data.Models.Products;
using Aujourdhui.Data.Models.Recipes;
using Aujourdhui.Data.Models.Storage;
using Aujourdhui.Extensions;
using Aujourdhui.Extensions.EnumExtensions;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aujourdhui.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        #region Basic
        public DbSet<Firm> Firms { get; set; }
        public DbSet<FileReference> FileReferences { get; set; }
        public DbSet<Country> Countries { get; set; }
        #endregion

        #region Languages
        public DbSet<Content> Contents { get; set; }
        public DbSet<Key> Keys { get; set; }
        public DbSet<LanguageValue> Languages { get; set; }
        public DbSet<LanguageKey> LanguageKeys { get; set; }
        public DbSet<Translation> Translations { get; set; }
        #endregion

        #region Products
        public DbSet<Category> Categories { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<PricePolicy> PricePolicies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<SpecificationOption> SpecificationOptions { get; set; }
        #endregion

        #region Recipes
        public DbSet<Group> Group { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeDifficultyLevelValue> RecipeDifficultyLevels { get; set; }
        public DbSet<RecipeItem> RecipeItems { get; set; }
        public DbSet<RecipeItemIngredient> RecipeItemIngredients { get; set; }
        public DbSet<RecipeItemTypeValue> RecipeItemTypes { get; set; }
        public DbSet<ReleasedRecipe> ReleasedRecipes { get; set; }
        #endregion

        #region Storage
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<CommodityLink> CommodityLinks { get; set; }
        public DbSet<PortionTypeValue> PortionTypes { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseConsumption> PurchaseConsumptions { get; set; }
        #endregion

        public IEnumerable<IEntityType> EntityTypes => Model.GetEntityTypes();

        public ApplicationDbContext(DbContextOptions options,
                                    IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Enums
            #region PortionType
            builder.Entity<Purchase>()
                   .Property(e => e.PortionType)
                   .HasConversion<int>();

            builder.Entity<PortionTypeValue>()
                   .Property(e => e.PortionType)
                   .HasConversion<int>();

            builder.Entity<PortionTypeValue>().HasData(
                    Enum.GetValues<PortionType>().Select(e => new PortionTypeValue()
                    {
                        PortionType = e,
                        Name = e.ToString(),
                        Units = e.GetDescription()
                    })
                );
            #endregion
            #region RecipeDifficultyLevel
            builder.Entity<Recipe>()
                   .Property(e => e.RecipeDifficultyLevel)
                   .HasConversion<int?>();

            builder.Entity<RecipeDifficultyLevelValue>()
                   .Property(e => e.RecipeDifficultyLevel)
                   .HasConversion<int>();

            builder.Entity<RecipeDifficultyLevelValue>().HasData(
                    Enum.GetValues<RecipeDifficultyLevel>().Select(e => new RecipeDifficultyLevelValue()
                    {
                        RecipeDifficultyLevel = e,
                        Name = e.ToString(),
                        Description = e.GetDescription()
                    })
                );
            #endregion
            #region RecipeItemType
            builder.Entity<RecipeItem>()
                   .Property(e => e.RecipeItemType)
                   .HasConversion<int?>();

            builder.Entity<RecipeItemTypeValue>()
                   .Property(e => e.RecipeItemType)
                   .HasConversion<int>();

            builder.Entity<RecipeItemTypeValue>().HasData(
                    Enum.GetValues<RecipeItemType>().Select(e => new RecipeItemTypeValue()
                    {
                        RecipeItemType = e,
                        Name = e.ToString()
                    })
                );
            #endregion
            #region Languages
            builder.Entity<Content>()
                   .Property(e => e.Language)
                   .HasConversion<int>();

            builder.Entity<LanguageKey>()
                   .Property(e => e.Language)
                   .HasConversion<int>();

            builder.Entity<Translation>()
                   .Property(e => e.Language)
                   .HasConversion<int>();

            builder.Entity<LanguageValue>()
                   .Property(e => e.Language)
                   .HasConversion<int>();

            builder.Entity<LanguageValue>().HasData(
                    Enum.GetValues<Language>().Select(e => new LanguageValue()
                    {
                        Language = e,
                        Name = e.ToString(),
                        Code = e.GetDescription()
                    })
                );
            #endregion
            #endregion

            #region Identities
            #region Roles
            builder.Entity<IdentityRole>().HasData(
                    Enum.GetValues<Constants.Role>().Select(e => new IdentityRole()
                    {
                        Id = ((int)e).ToString(),
                        Name = e.ToString(),
                        NormalizedName = e.ToString().ToUpper()
                    })
                );
            #endregion

            #region Users
            var hasher = new PasswordHasher<ApplicationUser>();
            var user = new ApplicationUser
            {
                Email = "nikita.dermenzhi@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "NIKITA.DERMENZHI@GMAIL.COM",
                FirstName = "Nikita",
                LastName = "Dermenzhi",
                MiddleName = "A.",
                UserName = "master",
                NormalizedUserName = "MASTER",
                PhoneNumber = "+380687379427",
                PhoneNumberConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "QwErty123")
            };
            builder.Entity<ApplicationUser>().HasData(user);
            #endregion

            #region UserRoles
            builder.Entity<IdentityUserRole<string>>()
                   .HasData(new IdentityUserRole<string>
                   {
                       RoleId = ((int)Constants.Role.Master).ToString(),
                       UserId = user.Id
                   });
            #endregion
            #endregion

            #region Unique Guids
            builder.Entity<Country>().HasAlternateKey(x => x.Guid);
            builder.Entity<FileReference>().HasAlternateKey(x => x.Guid);
            builder.Entity<Firm>().HasAlternateKey(x => x.Guid);
            builder.Entity<Content>().HasAlternateKey(x => x.Guid);
            builder.Entity<Key>().HasAlternateKey(x => x.Guid);
            builder.Entity<LanguageKey>().HasAlternateKey(x => x.Guid);
            builder.Entity<Translation>().HasAlternateKey(x => x.Guid);
            builder.Entity<Category>().HasAlternateKey(x => x.Guid);
            builder.Entity<Option>().HasAlternateKey(x => x.Guid);
            builder.Entity<PricePolicy>().HasAlternateKey(x => x.Guid);
            builder.Entity<Product>().HasAlternateKey(x => x.Guid);
            builder.Entity<Property>().HasAlternateKey(x => x.Guid);
            builder.Entity<Specification>().HasAlternateKey(x => x.Guid);
            builder.Entity<SpecificationOption>().HasAlternateKey(x => x.Guid);
            builder.Entity<Group>().HasAlternateKey(x => x.Guid);
            builder.Entity<Ingredient>().HasAlternateKey(x => x.Guid);
            builder.Entity<Recipe>().HasAlternateKey(x => x.Guid);
            builder.Entity<RecipeItem>().HasAlternateKey(x => x.Guid);
            builder.Entity<RecipeItemIngredient>().HasAlternateKey(x => x.Guid);
            builder.Entity<ReleasedRecipe>().HasAlternateKey(x => x.Guid);
            builder.Entity<Commodity>().HasAlternateKey(x => x.Guid);
            builder.Entity<CommodityLink>().HasAlternateKey(x => x.Guid);
            builder.Entity<Purchase>().HasAlternateKey(x => x.Guid);
            builder.Entity<PurchaseConsumption>().HasAlternateKey(x => x.Guid);
            #endregion

            base.OnModelCreating(builder);
        }
    }
}
