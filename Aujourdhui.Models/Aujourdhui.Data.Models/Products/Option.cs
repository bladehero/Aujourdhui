using Aujourdhui.Data.Models.Essentials;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aujourdhui.Data.Models.Products
{
    public class Option : IndividualModel
    {
        [Required]
        public string Name { get; set; }

        public ICollection<SpecificationOption> SpecificationOptions { get; set; }

        public Option()
        {
            SpecificationOptions = new List<SpecificationOption>();
        }
    }
}
