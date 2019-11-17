using System.Collections.Generic;
using System.Linq;
using EscapeRoomCritic.Core.DTOs.Users;
using EscapeRoomCritic.Core.Exceptions;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Repositories;

namespace EscapeRoomCritic.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EscapeRoomCriticDbContext _dbContext;

        public UserRepository(EscapeRoomCriticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            if(_dbContext.Users.Any(e => e.Username == user.Username)) throw new ValueAlreadyExistException("There is already user with that username");
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public User Edit(int id, EditUserDto user)
        {
            var userEntity = _dbContext.Users.FirstOrDefault(e => e.UserId == id);
            if(userEntity == null) throw new CanNotFindValueException($"There is no user with {id} id");
            userEntity.Role = user.Role;
            userEntity.FirstName = user.FirstName;
            userEntity.LastName = user.LastName;
            userEntity.Username = user.Username;
            userEntity.Password = user.Password;
            _dbContext.SaveChanges();
            return _dbContext.Users.Find(id);
        }

        public void Remove(int userId)
        {
            var user = _dbContext.Users.Find(userId);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();          
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users;
        }

        public User FindById(int userId)
        {
            if(_dbContext.Users.Any(e => e.UserId == userId) == false) throw new CanNotFindValueException($"User with id {userId} does not exist");
            return _dbContext.Users.FirstOrDefault(e => e.UserId == userId);
        }

        public User CheckCredentials(string username, string password)
        {
            return _dbContext.Users.FirstOrDefault(e => e.Username == username && e.Password == password);
        }
    }
}