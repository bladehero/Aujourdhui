using Aujourdhui.Data.Models.Essentials;
using System;

namespace Aujourdhui.Data.Models
{
    public class ImageReference : KeyModel
    {
        public string Table { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int ObjectId { get; set; }
    }
}
