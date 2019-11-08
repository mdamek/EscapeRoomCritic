using System.Collections.Generic;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Repositories;

namespace EscapeRoomCritic.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            var allUsers = _userRepository.GetUsers();
            return allUsers;
        }

        public User GetById(int id)
        {
            return _userRepository.FindById(id);
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public User Edit(int id, User user)
        {
            return _userRepository.Edit(id, user);
        }

        public void Delete(int id)
        {
            _userRepository.Remove(id);
        }


    }
}
