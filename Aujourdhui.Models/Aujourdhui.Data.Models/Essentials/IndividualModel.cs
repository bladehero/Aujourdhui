using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Essentials
{
    public abstract class IndividualModel : ServiceModel
    {
        [Required]
        public string CreatedByUserID { get; set; }
        [ForeignKey(nameof(CreatedByUserID))]
        public ApplicationUser CreatedBy { get; set; }

        [Required]
        public string ModifiedByUserID { get; set; }
        [ForeignKey(nameof(ModifiedByUserID))]
        public ApplicationUser ModifiedBy { get; set; }
    }
}
