using Aujourdhui.Data.Models.Essentials;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Products
{
    public class SpecificationOption : IndividualModel
    {
        public int? SpecificationID { get; set; }
        [ForeignKey(nameof(SpecificationID))]
        public Specification Specification { get; set; }

        public int? OptionID { get; set; }
        [ForeignKey(nameof(OptionID))]
        public Option Option { get; set; }

        public string Value { get; set; }
    }
}
