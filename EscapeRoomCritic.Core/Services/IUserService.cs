using System.Collections.Generic;
using EscapeRoomCritic.Core.DTOs.Users;

namespace EscapeRoomCritic.Core.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        UserDto GetById(int id);
        void Add(NewUserDto user);
        void Edit(int id, EditUserDto editUser);
        void Delete(int id);
    }
}
