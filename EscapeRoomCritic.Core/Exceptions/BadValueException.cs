using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoomCritic.Core.Exceptions
{
    public class BadValueException : Exception
    {
        public BadValueException() { }
        public BadValueException(string message) : base(message) { }
    }
}
