using Aujourdhui.Data.Models.Essentials;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Languages
{
    // Should be used for large texts
    public class Content : IndividualModel
    {
        [Required]
        public string Table { get; set; }
        [Required]
        public string Property { get; set; }

        public Language LanguageID { get; set; }
        [ForeignKey(nameof(LanguageID))]
        public LanguageValue Language { get; set; }

        public ICollection<Translation> Translations { get; set; }

        public Content()
        {
            Translations = new List<Translation>();
        }
    }
}
