using Aujourdhui.Data.Models.Essentials;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aujourdhui.Data.Models.Languages
{
    public class LanguageValue : KeyModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }

        public ICollection<LanguageKey> LanguageKeys { get; set; }
        public ICollection<Translation> Translations { get; set; }

        public LanguageValue()
        {
            LanguageKeys = new List<LanguageKey>();
            Translations = new List<Translation>();
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
