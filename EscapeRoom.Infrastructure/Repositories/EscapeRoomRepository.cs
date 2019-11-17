using System.Collections.Generic;
using System.Linq;
using EscapeRoomCritic.Core.DTOs.EscapeRooms;
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
        public void Add(EscapeRoom escapeRoom)
        {
            using (var context = _dbContext)
            {
                if (context.EscapeRooms.Any(e => e.Name == escapeRoom.Name)) throw new ValueAlreadyExistException("There is already escape room with that name");
                context.Add(escapeRoom);
                context.SaveChanges();
            }
        }

        public EscapeRoom Edit(int id, EditEscapeRoomDto escapeRoom)
        {
            var escapeRoomEntity = _dbContext.EscapeRooms.FirstOrDefault(e => e.EscapeRoomId == id);
            if(escapeRoomEntity == null) throw new CanNotFindValueException($"Escape room with {id} do not exits");

            escapeRoomEntity.Name = escapeRoom.Name;
            escapeRoomEntity.Time = escapeRoom.Time;
            escapeRoomEntity.BuildingNumber = escapeRoom.BuildingNumber;
            escapeRoomEntity.City = escapeRoom.City;
            escapeRoomEntity.Street = escapeRoom.Street;
            escapeRoomEntity.Category = escapeRoom.Category;
            escapeRoomEntity.Description = escapeRoom.Description;
            escapeRoomEntity.Email = escapeRoom.Email;
            escapeRoomEntity.ForAdult = escapeRoom.ForAdult;
            escapeRoomEntity.MaxPeopleNumber = escapeRoom.MaxPeopleNumber;
            escapeRoomEntity.PhoneNumber = escapeRoom.PhoneNumber;
            escapeRoomEntity.Price = escapeRoom.Price;

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
