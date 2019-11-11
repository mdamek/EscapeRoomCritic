using System;

namespace EscapeRoomCritic.Core.Exceptions
{
    public class ValueAlreadyExistException : Exception
    {
        public ValueAlreadyExistException() { }
        public ValueAlreadyExistException(string message) : base(message) { }
    }
}
