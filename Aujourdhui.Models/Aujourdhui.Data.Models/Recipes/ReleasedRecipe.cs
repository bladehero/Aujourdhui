using Aujourdhui.Data.Models.Essentials;
using Aujourdhui.Data.Models.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Recipes
{
    /// <summary>
    /// Created recipe as a product
    /// </summary>
    public class ReleasedRecipe : IndividualModel
    {
        public int RecipeID { get; set; }
        [ForeignKey(nameof(RecipeID))]
        public Recipe Recipe { get; set; }

        public DateTime Released { get; set; }

        public ICollection<PurchaseConsumption> PurchaseConsumptions { get; set; }

        public ReleasedRecipe()
        {
            PurchaseConsumptions = new List<PurchaseConsumption>();
        }
    }
}
