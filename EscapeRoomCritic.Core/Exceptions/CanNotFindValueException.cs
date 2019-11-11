using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoomCritic.Core.Exceptions
{
    public class CanNotFindValueException : Exception
    {
        public CanNotFindValueException() { }
        public CanNotFindValueException(string message) : base(message) { }
    }
}
