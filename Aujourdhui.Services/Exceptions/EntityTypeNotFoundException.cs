using System;

#nullable enable

namespace Aujourdhui.Services.Exceptions
{
    [Serializable]
    public class EntityTypeNotFoundException : Exception
    {
        public string? Entity { get; set; }

        public EntityTypeNotFoundException() { }
        public EntityTypeNotFoundException(string? entity)
            : this(entity, null) { }
        public EntityTypeNotFoundException(string? entity, Exception? innerException)
            : base($"Provided table {(string.IsNullOrWhiteSpace(entity) ? string.Empty : $"with a name `{entity}`")} is not found!", innerException)
        {
            Entity = entity;
        }
    }
}
