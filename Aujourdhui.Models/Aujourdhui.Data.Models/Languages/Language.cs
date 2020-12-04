using Aujourdhui.Data.Models.Essentials;
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
    }

    public enum Language
    {
        [Description("en")]
        English,
        [Description("ru")]
        Russian
    }
}
