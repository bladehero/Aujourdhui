using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aujourdhui.Data.Models.Languages
{
    public class LanguageValue
    {
        [Key]
        public Language Language { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }

        public ICollection<LanguageKey> LanguageKeys { get; set; }
        public ICollection<Translation> Translations { get; set; }
        public ICollection<Country> Countries { get; set; }

        public LanguageValue()
        {
            LanguageKeys = new List<LanguageKey>();
            Translations = new List<Translation>();
            Countries = new List<Country>();
        }
    }

    public enum Language
    {
        [Description("en")]
        English,
        [Description("ru")]
        Russian
    }
}
