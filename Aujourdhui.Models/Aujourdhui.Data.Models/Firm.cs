using Aujourdhui.Data.Models.Essentials;
using Aujourdhui.Data.Models.Recipies;
using System.Collections.Generic;

namespace Aujourdhui.Data.Models
{
    public class Firm : IndividualModel
    {
        public string Key { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public Firm()
        {
            Ingredients = new List<Ingredient>();
        }
    }
}
