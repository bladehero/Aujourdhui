using Aujourdhui.Data.Models.Essentials;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aujourdhui.Data.Models.Languages
{
    public class Key : KeyModel
    {
        [Required]
        public string Name { get; set; }
        public string Table { get; set; }
        public string Default { get; set; }

        public ICollection<LanguageKey> LanguageKeys { get; set; }

        public Key()
        {
            LanguageKeys = new List<LanguageKey>();
        }
    }
}
