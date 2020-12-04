using Aujourdhui.Data.Models.Essentials;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Products
{
    public class Specification : IndividualModel
    {
        public int ProductID { get; set; }
        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }

        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
    }
}
