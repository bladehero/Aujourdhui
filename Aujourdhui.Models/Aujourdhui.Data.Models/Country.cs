using Aujourdhui.Data.Models.Essentials;
using Aujourdhui.Data.Models.Languages;
using System.Collections.Generic;

namespace Aujourdhui.Data.Models
{
    public class Country : KeyModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<LanguageValue> Languages { get; set; }

        public Country()
        {
            Languages = new List<LanguageValue>();
        }
    }
}
