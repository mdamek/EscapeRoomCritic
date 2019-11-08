using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Repositories;
using Microsoft.EntityFrameworkCore;

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
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public User Edit(int id, User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
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
            return _dbContext.Users.Find(userId);
        }

        public User CheckCredentials(string username, string password)
        {
            return _dbContext.Users.AsQueryable().FirstOrDefault(e => e.Username == username && e.Password == password);
        }
    }
}
