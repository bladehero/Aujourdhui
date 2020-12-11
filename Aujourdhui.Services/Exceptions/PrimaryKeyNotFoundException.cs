using System;

#nullable enable

namespace Aujourdhui.Services.Exceptions
{
    public class PrimaryKeyNotFoundException : Exception
    {
        public PrimaryKeyNotFoundException() { }
        public PrimaryKeyNotFoundException(string? message)
            : base(message) { }
        public PrimaryKeyNotFoundException(string? message, Exception? innerException)
            : base(message, innerException) { }
    }
}
