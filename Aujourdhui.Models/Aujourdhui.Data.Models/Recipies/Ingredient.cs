using Aujourdhui.Data.Models.Essentials;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Recipies
{
    public class Ingredient : IndividualModel
    {
        [Required]
        public string Name { get; set; }
        [Range(0, int.MaxValue)]
        public int ExpirationInDays { get; set; }
        [Range(0.0, double.MaxValue)]
        public double Protein { get; set; }
        [Range(0.0, double.MaxValue)]
        public double Fat { get; set; }
        [Range(0.0, double.MaxValue)]
        public double Carbohydrates { get; set; }
        [Range(0.0, double.MaxValue)]
        public double Alcohol { get; set; }
        [Range(0.0, double.MaxValue)]
        public double Calories { get; set; }

        public decimal? EstimatedCost { get; set; }

        public int FirmID { get; set; }
        [ForeignKey(nameof(FirmID))]
        public Firm Firm { get; set; }

        public ICollection<PurchasedIngredient> PurchasedIngredients { get; set; }

        public Ingredient()
        {
            PurchasedIngredients = new List<PurchasedIngredient>();
        }
    }
}
