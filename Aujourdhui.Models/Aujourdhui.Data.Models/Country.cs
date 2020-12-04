
using Aujourdhui.Data.Models.Essentials;

namespace Aujourdhui.Data.Models
{
    public class Country : KeyModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ImageUrl { get; set; }
    }
}
