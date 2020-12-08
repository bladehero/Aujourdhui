using Microsoft.EntityFrameworkCore.Metadata;
using System;

#nullable enable

namespace Aujourdhui.Services.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public int ObjectId { get; set; }
        public IEntityType? EntityType { get; set; }

        public EntityNotFoundException() { }
        public EntityNotFoundException(int objectId, IEntityType? entityType)
            : this(objectId, entityType, null) { }
        public EntityNotFoundException(int objectId, IEntityType? entityType, Exception? innerException)
            : base($"Provided entity {(entityType is null ? string.Empty : $"of a type `{entityType.Name}`")} with {nameof(ObjectId)}: {objectId} is not found!", innerException)
        {
            ObjectId = objectId;
            EntityType = entityType;
        }
    }
}
