using Aujourdhui.Data.Models.Essentials;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Languages
{
    /// <summary>
    /// Should be used for small key-values
    /// </summary>
    public class LanguageKey : KeyModel
    {
        public Language Language { get; set; }
        [ForeignKey(nameof(Language))]
        public LanguageValue LanguageValue { get; set; }

        public int KeyID { get; set; }
        [ForeignKey(nameof(KeyID))]
        public Key Key { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
