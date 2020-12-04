using Aujourdhui.Data.Models.Essentials;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Recipies
{
    public class RecipeItem : IndividualModel
    {
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
