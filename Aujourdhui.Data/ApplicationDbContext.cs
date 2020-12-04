﻿using Aujourdhui.Data.Models;
using Aujourdhui.Data.Models.Products;
using Aujourdhui.Data.Models.Recipies;
using Aujourdhui.Extensions.EnumExtensions;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace Aujourdhui.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        #region Basic
        public DbSet<Firm> Firms { get; set; }
        public DbSet<ImageReference> ImageReferences { get; set; }
        public DbSet<Country> Countries { get; set; }
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

        #region Recipies
        public DbSet<Group> Group { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PortionTypeValue> PortionTypes { get; set; }
        public DbSet<PurchasedIngredient> PurchasedIngredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeDifficultyLevelValue> RecipeDifficultyLevels { get; set; }
        public DbSet<RecipeItem> RecipeItems { get; set; }
        public DbSet<RecipeItemIngredient> RecipeItemIngredients { get; set; }
        public DbSet<RecipeItemTypeValue> RecipeItemTypes { get; set; }
        #endregion

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Enums intialization
            #region PortionType
            builder.Entity<PurchasedIngredient>()
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
            #endregion

            base.OnModelCreating(builder);
        }
    }
}
