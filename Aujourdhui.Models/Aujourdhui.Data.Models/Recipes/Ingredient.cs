using Aujourdhui.Data.Models.Essentials;
using Aujourdhui.Data.Models.Storage;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aujourdhui.Data.Models.Recipes
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

        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<Commodity> Commodities { get; set; }

        public Ingredient()
        {
            Recipes = new List<Recipe>();
        }
    }
}
