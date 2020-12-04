using System;

namespace Aujourdhui.Data.Models.Essentials
{
    public abstract class ServiceModel : KeyModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }

        public ServiceModel()
        {
            var now = DateTime.Now;
            DateCreated = DateModified = now;
        }
    }
}
