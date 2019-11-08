using System.Collections.Generic;
using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        User Edit(int id, User user);
        void Remove(int userId);
        IEnumerable<User> GetUsers();
        User FindById(int userId);
        User CheckCredentials(string username, string password);
    }
}
