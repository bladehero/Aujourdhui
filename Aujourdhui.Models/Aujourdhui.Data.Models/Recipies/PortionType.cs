using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aujourdhui.Data.Models.Recipies
{
    public class PortionTypeValue
    {
        [Key]
        public PortionType PortionType { get; set; }

        public string Name { get; set; }
        public string Units { get; set; }
    }

    public enum PortionType
    {
        [Description("pcs.")]
        Pieces,
        [Description("ml.")]
        Volumetric,
        [Description("g.")]
        Weight
    }
}
