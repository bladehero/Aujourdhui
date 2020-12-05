using System.ComponentModel.DataAnnotations;

namespace Aujourdhui.Data.Models.Recipes
{
    public class RecipeItemTypeValue
    {
        [Key]
        public RecipeItemType RecipeItemType { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public enum RecipeItemType
    {
        Paragraph,
        Header,
        Image
    }
}
