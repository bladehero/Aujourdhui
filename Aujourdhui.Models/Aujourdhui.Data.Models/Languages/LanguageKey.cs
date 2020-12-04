using Aujourdhui.Data.Models.Essentials;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Languages
{
    public class LanguageKey : KeyModel
    {
        public Language LanguageID { get; set; }
        [ForeignKey(nameof(LanguageID))]
        public LanguageValue Language { get; set; }

        public int KeyID { get; set; }
        [ForeignKey(nameof(KeyID))]
        public Key Key { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
