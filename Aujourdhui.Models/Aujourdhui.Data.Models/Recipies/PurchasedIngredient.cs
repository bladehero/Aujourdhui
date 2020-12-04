using Aujourdhui.Data.Models.Essentials;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Recipies
{
    public class PurchasedIngredient : IndividualModel
    {
        public DateTime? DateProduced { get; set; }
        public DateTime? DateExpiration { get; set; }

        [Range(0.0, double.MaxValue)]
        public double Cost { get; set; }

        [Range(0.0, double.MaxValue)]
        public double Portion { get; set; }

        public PortionType PortionType { get; set; }
        [ForeignKey(nameof(PortionType))]
        public PortionTypeValue PortionTypeValue { get; set; }

        public int IngredientID { get; set; }
        [ForeignKey(nameof(IngredientID))]
        public Ingredient Ingredient { get; set; }
    }
}
