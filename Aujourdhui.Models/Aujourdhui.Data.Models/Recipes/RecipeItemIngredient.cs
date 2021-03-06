﻿using Aujourdhui.Data.Models.Essentials;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Recipes
{
    public class RecipeItemIngredient : IndividualModel
    {
        /// <summary>
        /// Representation value of ingredient name
        /// </summary>
        [Required]
        public string Text { get; set; }

        public int RecipeItemID { get; set; }
        [ForeignKey(nameof(RecipeItemID))]
        public RecipeItem RecipeItem { get; set; }

        public int? IngredientID { get; set; }
        [ForeignKey(nameof(IngredientID))]
        public Ingredient Ingredient { get; set; }
    }
}
