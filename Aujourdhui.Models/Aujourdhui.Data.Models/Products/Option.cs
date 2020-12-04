using Aujourdhui.Data.Models.Essentials;
using System.Collections.Generic;

namespace Aujourdhui.Data.Models.Products
{
    public class Option : IndividualModel
    {
        public string Name { get; set; }

        public ICollection<SpecificationOption> SpecificationOptions { get; set; }

        public Option()
        {
            SpecificationOptions = new List<SpecificationOption>();
        }
    }
}
