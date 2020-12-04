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

        public Language Language { get; set; }
        [ForeignKey(nameof(Language))]
        public LanguageValue LanguageValue { get; set; }

        public ICollection<Translation> Translations { get; set; }

        public Content()
        {
            Translations = new List<Translation>();
        }
    }
}
