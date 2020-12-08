using System;

#nullable enable

namespace Aujourdhui.Services.Exceptions
{
    public class FileReferenceNotFound : Exception
    {
        public int? ObjectId { get; set; }
        public string? Entity { get; set; }
        public Guid? Guid { get; set; }

        public FileReferenceNotFound(Guid guid)
            : this(guid, null) { }
        public FileReferenceNotFound(Guid guid, Exception? innerException)
            : base($"File reference with {nameof(Guid)}: {guid} is not found!", innerException)
        {
            Guid = guid;
        }
        public FileReferenceNotFound(int objectId, string entity)
            : this(objectId, entity, null) { }
        public FileReferenceNotFound(int objectId, string entity, Exception? innerException)
            : base($"File reference of a type `{nameof(Entity)}` with {nameof(ObjectId)}: {objectId} is not found!", innerException) 
        {
            Entity = entity;
        }
    }
}
