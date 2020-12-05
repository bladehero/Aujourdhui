using Aujourdhui.Data.Models.Essentials;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Recipes
{
    /// <summary>
    /// Text of recipe plan with using ingredient reference if it's needed
    /// </summary>
    public class RecipeItem : IndividualModel
    {
        /// <summary>
        /// Can be save with {{ key }} to use reference to Ingredient from recipe list of them 
        /// </summary>
        [Required]
        public string Value { get; set; }
        public int? DurationInMinutes { get; set; }

        public RecipeItemType RecipeItemType { get; set; }
        [ForeignKey(nameof(RecipeItemType))]
        public RecipeItemTypeValue RecipeItemTypeValue { get; set; }

        public int RecipeID { get; set; }
        [ForeignKey(nameof(RecipeID))]
        public Recipe Recipe { get; set; }

        public ICollection<RecipeItemIngredient> Ingredient { get; set; }
    }
}
