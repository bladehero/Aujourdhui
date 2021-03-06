﻿using Aujourdhui.Data.Models.Essentials;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aujourdhui.Data.Models.Products
{
    public class Category : KeyModel
    {
        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Position { get; set; }

        public int? ParentID { get; set; }
        [ForeignKey(nameof(ParentID))]
        public Category Parent { get; set; }

        public ICollection<Category> Children { get; set; }
        public ICollection<Product> Products { get; set; }

        public Category()
        {
            Children = new List<Category>();
            Products = new List<Product>();
        }
    }
}
