using EscapeRoomCritic.Core.DTOs;

namespace EscapeRoomCritic.Core.Services
{
    public interface IIdentityService
    {
        UserTokenDto Authenticate(string username, string password);
    }
}
