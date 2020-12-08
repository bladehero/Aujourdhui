using Aujourdhui.Data.Models.Essentials;
using System;

namespace Aujourdhui.Data.Models
{
    public class FileReference : KeyModel
    {
        public string Entity { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int ObjectId { get; set; }
    }
}
