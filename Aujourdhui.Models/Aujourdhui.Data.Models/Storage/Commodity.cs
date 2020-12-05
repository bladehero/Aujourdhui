using Aujourdhui.Data.Models.Essentials;
using Aujourdhui.Data.Models.Recipes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Storage
{
    /// <summary>
    /// List of possible products for user
    /// </summary>
    public class Commodity : IndividualModel
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

        public int? FirmID { get; set; }
        [ForeignKey(nameof(FirmID))]
        public Firm Firm { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<CommodityLink> CommodityLinks { get; set; }

        public Commodity()
        {
            Ingredients = new List<Ingredient>();
            CommodityLinks = new List<CommodityLink>();
        }
    }
}
