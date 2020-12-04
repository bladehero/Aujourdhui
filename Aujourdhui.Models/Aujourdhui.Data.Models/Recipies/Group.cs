using Aujourdhui.Data.Models.Essentials;

namespace Aujourdhui.Data.Models.Recipies
{
    public class Group : IndividualModel
    {
        public string Name { get; set; }
        public decimal? EstimatedPrice { get; set; }
    }
}
