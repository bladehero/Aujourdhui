using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aujourdhui.Data.Models.Recipes
{
    public class RecipeDifficultyLevelValue
    {
        [Key]
        public RecipeDifficultyLevel RecipeDifficultyLevel { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }

    public enum RecipeDifficultyLevel
    {
        [Description("No knowledge at all of the topic")] Beginner,
        [Description("A very basic knowledge of the topic but no professional usage")] Basic,
        [Description("A basic knowledge of the topic but no regular professional usage")] Intermediate,
        [Description("A good knowledge of the topic and a regular professional usage")] Advanced,
        [Description("A perfect knowledge of the topic and a daily professional usage")] Expert
    }
}
