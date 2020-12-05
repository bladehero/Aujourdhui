using Aujourdhui.Data.Models.Essentials;
using Aujourdhui.Data.Models.Recipes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Products
{
    public class Product : IndividualModel
    {
        [Required]
        public string Name { get; set; }

        public int? ReleasedRecipeID { get; set; }
        [ForeignKey(nameof(ReleasedRecipeID))]
        public ReleasedRecipe ReleasedRecipe { get; set; }

        public int? FirmID { get; set; }
        [ForeignKey(nameof(FirmID))]
        public Firm Firm { get; set; }

        public ICollection<Category> Categories { get; set; }
        public ICollection<Property> Properties { get; set; }

        public Product()
        {
            Categories = new List<Category>();
            Properties = new List<Property>();
        }
    }
}
