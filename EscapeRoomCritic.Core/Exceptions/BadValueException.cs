using System;

namespace EscapeRoomCritic.Core.Exceptions
{
    public class BadValueException : Exception
    {
        public BadValueException() { }
        public BadValueException(string message) : base(message) { }
    }
}
