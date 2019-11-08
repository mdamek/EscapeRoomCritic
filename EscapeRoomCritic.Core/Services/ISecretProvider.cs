using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoomCritic.Core.Services
{
    public interface ISecretProvider
    {
        string GetSecret();
    }
}
