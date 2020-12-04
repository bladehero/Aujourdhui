using Aujourdhui.Data.Models.Essentials;
using System.ComponentModel.DataAnnotations;

namespace Aujourdhui.Data.Models.Recipies
{
    public class Group : IndividualModel
    {
        [Required]
        public string Name { get; set; }
        public decimal? EstimatedPrice { get; set; }
    }
}
