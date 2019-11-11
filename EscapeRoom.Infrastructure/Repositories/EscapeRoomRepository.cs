using System.Collections.Generic;
using System.Linq;
using EscapeRoomCritic.Core.Exceptions;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Repositories;

namespace EscapeRoomCritic.Infrastructure.Repositories
{
    public class EscapeRoomRepository : IEscapeRoomRepository
    {
        private readonly EscapeRoomCriticDbContext _dbContext;

        public EscapeRoomRepository(EscapeRoomCriticDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(EscapeRoom escapeRoom, int userId)
        {
            using (var context = _dbContext)
            {
                if (context.EscapeRooms.Any(e => e.Name == escapeRoom.Name)) throw new ValueAlreadyExistException("There is already escape room with that name");
                var user = context.Users.Find(userId);
                context.Attach(user);
                context.Attach(escapeRoom);
                user.EscapeRooms.Add(escapeRoom);
                context.SaveChanges();
            }
        }

        public EscapeRoom Edit(int id, EscapeRoom escapeRoom)
        {
            _dbContext.Update(escapeRoom);
            _dbContext.Entry(escapeRoom).Property(x => x.EscapeRoomId).IsModified = false;
            _dbContext.Entry(escapeRoom).Property(x => x.UserId).IsModified = false;
            _dbContext.Entry(escapeRoom).Reference(e => e.Owner).IsModified = false;
            _dbContext.SaveChanges();
            return _dbContext.EscapeRooms.Find(id);
        }

        public void Remove(int escapeRoomId)
        {
            var escapeRoom = _dbContext.EscapeRooms.Find(escapeRoomId);
            _dbContext.EscapeRooms.Remove(escapeRoom);
            _dbContext.SaveChanges();
        }

        public IEnumerable<EscapeRoom> GetEscapeRooms()
        {
            return _dbContext.EscapeRooms;
        }

        public EscapeRoom FindById(int escapeRoomId)
        {
            return _dbContext.EscapeRooms.FirstOrDefault(e => e.EscapeRoomId == escapeRoomId);
        }
    }
}
