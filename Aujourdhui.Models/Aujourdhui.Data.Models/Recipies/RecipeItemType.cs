﻿using System.ComponentModel.DataAnnotations;

namespace Aujourdhui.Data.Models.Recipies
{
    public class RecipeItemTypeValue
    {
        [Key]
        public RecipeItemType RecipeItemType { get; set; }

        public string Name { get; set; }
    }

    public enum RecipeItemType
    {
        Paragraph,
        Header,
        Image
    }
}
