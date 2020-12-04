using Aujourdhui.Data.Models.Essentials;
using System.Collections.Generic;

namespace Aujourdhui.Data.Models.Products
{
    public class Property : IndividualModel
    {
        public string Value { get; set; }

        public ICollection<Product> Products { get; set; }
        public Property()
        {
            Products = new List<Product>();
        }
    }
}
