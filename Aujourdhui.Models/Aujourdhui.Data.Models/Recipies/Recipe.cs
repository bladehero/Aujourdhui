using Aujourdhui.Data.Models.Essentials;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Recipies
{
    public class Recipe : IndividualModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? EstimatedPrice { get; set; }

        public RecipeDifficultyLevel? RecipeDifficultyLevel { get; set; }
        [ForeignKey(nameof(RecipeDifficultyLevel))]
        public RecipeDifficultyLevelValue RecipeDifficultyLevelValue { get; set; }

        public int? GroupID { get; set; }
        [ForeignKey(nameof(GroupID))]
        public Group Group { get; set; }

        public ICollection<RecipeItem> RecipeItems { get; set; }
    }
}
