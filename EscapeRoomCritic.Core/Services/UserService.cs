using System.Collections.Generic;
using System.Linq;
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
            return allUsers.ToList().ConvertAll(e => new UserDto{FirstName = e.FirstName, LastName = e.LastName, Role = e.Role, Username = e.Username, Id = e.UserId});
        }
        
        public UserDto GetById(int id)
        {
            var user = _userRepository.FindById(id);
            return new UserDto{FirstName = user.FirstName, LastName = user.LastName, Username = user.Username, Role = user.Role, Id = user.UserId};
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

        public void Edit(EditUserDto editUser)
        {
            ValidateRoles(editUser.Role);
            _userRepository.Edit(editUser);
        }

        public void Delete(int id)
        {
            _userRepository.Remove(id);
        }

        private void ValidateRoles(string role)
        {
            if(string.IsNullOrWhiteSpace(role) || new List<string>{Role.Owner, Role.Admin, Role.Visitor}.Contains(role) == false) throw new BadValueException(role + " is not valid role"); 
        }
    }
}
