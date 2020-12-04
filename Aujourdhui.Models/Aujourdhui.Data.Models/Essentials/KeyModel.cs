using System;
using System.ComponentModel.DataAnnotations;

namespace Aujourdhui.Data.Models.Essentials
{
    public abstract class KeyModel
    {
        [Key]
        public virtual int ID { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
