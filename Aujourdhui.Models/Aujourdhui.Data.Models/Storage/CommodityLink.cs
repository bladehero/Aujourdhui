using Aujourdhui.Data.Models.Essentials;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Storage
{
    public class CommodityLink : IndividualModel
    {
        [Required]
        public string Url { get; set; }

        public int CommodityID { get; set; }
        [ForeignKey(nameof(CommodityID))]
        public Commodity Commodity { get; set; }
    }
}
