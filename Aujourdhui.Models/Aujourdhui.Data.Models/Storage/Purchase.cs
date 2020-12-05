using Aujourdhui.Data.Models.Essentials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Storage
{
    /// <summary>
    /// Commodity what was bought
    /// </summary>
    public class Purchase : IndividualModel
    {
        public DateTime? DateProduced { get; set; }
        public DateTime? DateExpiration { get; set; }

        [Range(0.0, double.MaxValue)]
        public double Cost { get; set; }

        [Range(0.0, double.MaxValue)]
        public double Portion { get; set; }

        public PortionType PortionType { get; set; }
        [ForeignKey(nameof(PortionType))]
        public PortionTypeValue PortionTypeValue { get; set; }

        public int CommodityID { get; set; }
        [ForeignKey(nameof(CommodityID))]
        public Commodity Commodity { get; set; }

        public ICollection<PurchaseConsumption> PurchaseConsumptions { get; set; }

        public Purchase()
        {
            PurchaseConsumptions = new List<PurchaseConsumption>();
        }
    }
}
