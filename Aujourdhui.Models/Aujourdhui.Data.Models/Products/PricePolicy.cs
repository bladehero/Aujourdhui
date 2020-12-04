using Aujourdhui.Data.Models.Essentials;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Products
{
    public class PricePolicy : IndividualModel
    {
        public int SpecificationID { get; set; }
        [ForeignKey(nameof(SpecificationID))]
        public Specification Specification { get; set; }

        [Range(2, int.MaxValue)]
        public int Count { get; set; }

        public decimal Price { get; set; }
    }
}
