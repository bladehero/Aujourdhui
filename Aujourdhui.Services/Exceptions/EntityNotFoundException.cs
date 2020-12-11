using Microsoft.EntityFrameworkCore.Metadata;
using System;

#nullable enable

namespace Aujourdhui.Services.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public Guid Guid { get; set; }
        public IEntityType? EntityType { get; set; }

        public EntityNotFoundException() { }
        public EntityNotFoundException(Guid guid, IEntityType? entityType)
            : this(guid, entityType, null) { }
        public EntityNotFoundException(Guid guid, IEntityType? entityType, Exception? innerException)
            : base($"Provided entity {(entityType is null ? string.Empty : $"of a type `{entityType.Name}`")} with {nameof(Guid)}: {guid} is not found!", innerException)
        {
            Guid = guid;
            EntityType = entityType;
        }
    }
}
