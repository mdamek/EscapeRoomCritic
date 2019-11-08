using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.Services
{
    public interface IIdentityService
    {
        User Authenticate(string username, string password);
    }
}
