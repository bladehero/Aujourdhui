using Aujourdhui.Data.Models.Essentials;
using Aujourdhui.Data.Models.Recipes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Storage
{
    /// <summary>
    /// Decrementing of purchases
    /// </summary>
    public class PurchaseConsumption : IndividualModel
    {
        public int PurchaseID { get; set; }
        [ForeignKey(nameof(PurchaseID))]
        public Purchase Purchase { get; set; }

        public int? ReleasedRecipeID { get; set; }
        [ForeignKey(nameof(ReleasedRecipeID))]
        public ReleasedRecipe ReleasedRecipe { get; set; }

        [Range(0.0, double.MaxValue)]
        public double Consumption { get; set; }

        public string Comment { get; set; }
    }
}
