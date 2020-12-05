using Aujourdhui.Data.Models.Essentials;
using Aujourdhui.Data.Models.Products;
using Aujourdhui.Data.Models.Storage;
using System.Collections.Generic;

namespace Aujourdhui.Data.Models
{
    public class Firm : IndividualModel
    {
        public string Key { get; set; }

        public ICollection<Commodity> Commodities { get; set; }
        public ICollection<Product> Products { get; set; }

        public Firm()
        {
            Commodities = new List<Commodity>();
            Products = new List<Product>();
        }
    }
}
