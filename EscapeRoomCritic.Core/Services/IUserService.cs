using System.Collections.Generic;
using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Add(User user);
        User Edit(int id, User user);
        void Delete(int id);
    }
}
