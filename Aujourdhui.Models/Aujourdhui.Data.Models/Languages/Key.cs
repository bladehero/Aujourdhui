using Aujourdhui.Data.Models.Essentials;
using System.ComponentModel.DataAnnotations;

namespace Aujourdhui.Data.Models.Languages
{
    public class Key : KeyModel
    {
        [Required]
        public string Name { get; set; }
        public string Default { get; set; }
    }
}
