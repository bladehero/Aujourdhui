using Aujourdhui.Data.Models.Essentials;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Languages
{
    // Should be used for large texts
    public class Translation : IndividualModel
    {
        public int? ContentID { get; set; }
        [ForeignKey(nameof(ContentID))]
        public Content Content { get; set; }

        public Language Language { get; set; }
        [ForeignKey(nameof(Language))]
        public LanguageValue LanguageValue { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
