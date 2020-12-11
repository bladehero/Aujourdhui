using Aujourdhui.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace Aujourdhui.Extensions.EntityFrameworkExtensions
{
    public static class EntityFrameworkExtensions
    {
        public static IProperty? GetPrimaryKeyProperty(this IEntityType entityType)
        {
            var primaryKey = entityType.FindPrimaryKey();
            var property = primaryKey.Properties.Count > 0 ? primaryKey.Properties[0] : null;
            return property;
        }

        public static int? GetIntegerPrimaryKey(this IEntityType entityType, object entity)
        {
            var property = GetPrimaryKeyProperty(entityType);
            if (property is null)
            {
                return null;
            }
            return (int?)entity.GetType().GetProperty(property.Name)!.GetValue(entity, null);
        }

        public static object ToObject(this IEntityType entityType, int objectId)
        {
            var property = GetPrimaryKeyProperty(entityType);
            object primaryKeyValue;
            if (property?.ClrType.IsEnum == true)
            {
                primaryKeyValue = Enum.ToObject(property.ClrType, objectId);
            }
            else
            {
                primaryKeyValue = objectId;
            }
            return primaryKeyValue;
        }
    }
}
