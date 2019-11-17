using System.Collections.Generic;
using System.Linq;
using EscapeRoomCritic.Core.DTOs.EscapeRooms;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Repositories;

namespace EscapeRoomCritic.Core.Services
{
    public class EscapeRoomService : IEscapeRoomService
    {
        private readonly IEscapeRoomRepository _escapeRoomRepository;

        public EscapeRoomService(IEscapeRoomRepository escapeRoomRepository)
        {
            _escapeRoomRepository = escapeRoomRepository;
        }

        public IEnumerable<EscapeRoomDto> GetAll()
        {
            var allEscapeRooms = _escapeRoomRepository.GetEscapeRooms();
            return allEscapeRooms.ToList().ConvertAll(e => new EscapeRoomDto
            {
                Category = e.Category, Description = e.Description, Email = e.Email, ForAdult = e.ForAdult,
                Name = e.Name, PhoneNumber = e.PhoneNumber, MaxPeopleNumber = e.MaxPeopleNumber,
                Time = e.Time, Price = e.Price, City = e.City, BuildingNumber = e.BuildingNumber, Street = e.Street, Id = e.EscapeRoomId
            });
        }

        public EscapeRoomDto GetById(int id)
        {
            var escapeRoom = _escapeRoomRepository.FindById(id);
            return new EscapeRoomDto
            {
                Category = escapeRoom.Category, Description = escapeRoom.Description, Email = escapeRoom.Email,
                ForAdult = escapeRoom.ForAdult, MaxPeopleNumber = escapeRoom.MaxPeopleNumber,
                Name = escapeRoom.Name, PhoneNumber = escapeRoom.PhoneNumber,
                Time = escapeRoom.Time, Price = escapeRoom.Price,
                City = escapeRoom.City,
                BuildingNumber = escapeRoom.BuildingNumber,
                Street = escapeRoom.Street, Id = escapeRoom.EscapeRoomId
            };
        }

        public void Add(NewEscapeRoomDto escapeRoom)
        {
            var newEscapeRoom = new EscapeRoom
            {
                Category = escapeRoom.Category, Description = escapeRoom.Description, Email = escapeRoom.Email,
                ForAdult = escapeRoom.ForAdult, MaxPeopleNumber = escapeRoom.MaxPeopleNumber,
                Name = escapeRoom.Name, PhoneNumber = escapeRoom.PhoneNumber, Price = escapeRoom.Price,
                Time = escapeRoom.Time, BuildingNumber = escapeRoom.BuildingNumber, Street = escapeRoom.Street, City = escapeRoom.City
            };
            _escapeRoomRepository.Add(newEscapeRoom);
        }


        public void Edit(int id, EditEscapeRoomDto escapeRoom)
        {

            _escapeRoomRepository.Edit(id, escapeRoom);
        }

        public void Delete(int id)
        {
            _escapeRoomRepository.Remove(id);
        }
    }
}