using System.Collections.Generic;
using System.Linq;
using EscapeRoomCritic.Core.DTOs;
using EscapeRoomCritic.Core.DTOs.Users;
using EscapeRoomCritic.Core.Exceptions;
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

        public IEnumerable<UserDto> GetAll()
        {
            var allUsers = _userRepository.GetUsers();
            return allUsers.ToList().ConvertAll(e => new UserDto{FirstName = e.FirstName, LastName = e.LastName, Role = e.Role, Username = e.Username});
        }

        public UserDto GetById(int id)
        {
            var user = _userRepository.FindById(id);
            return new UserDto{FirstName = user.FirstName, LastName = user.LastName, Username = user.Username, Role = user.Role};
        }

        public void Add(NewUserDto user)
        {
            ValidateRoles(user.Role);
            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Role = user.Role,
                Username = user.Username
            };
            _userRepository.Add(newUser);
        }

        public void Edit(int id, EditUserDto editUser)
        {
            ValidateRoles(editUser.Role);
            var user = new User
            {
                FirstName = editUser.FirstName,
                LastName = editUser.LastName,
                Password = editUser.Password,
                Role = editUser.Role,
                Username = editUser.Username
            };
            _userRepository.Edit(id, user);
        }

        public void Delete(int id)
        {
            _userRepository.Remove(id);
        }

        public void ValidateRoles(string role)
        {
            if(string.IsNullOrWhiteSpace(role) || role != Role.Visitor || role != Role.Owner || role != Role.Admin) throw new BadValueException(role + " is not valid role"); 
        }
    }
}
