using EscapeRoomCritic.Core.DTOs.Users;

namespace EscapeRoomCritic.Core.Services
{
    public interface IIdentityService
    {
        UserTokenDto Authenticate(string username, string password);
    }
}
