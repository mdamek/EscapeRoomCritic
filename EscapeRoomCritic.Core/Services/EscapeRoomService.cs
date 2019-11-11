using System.Collections.Generic;
using System.Linq;
using EscapeRoomCritic.Core.DTOs;
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
            var allEscapeRooms =  _escapeRoomRepository.GetEscapeRooms();
            return allEscapeRooms.ToList().ConvertAll(e => new EscapeRoomDto
            {
                Category = e.Category, Description = e.Description, Email = e.Email, ForAdult = e.ForAdult,
                Name = e.Name, OwnerId = e.UserId, PhoneNumber = e.PhoneNumber, MaxPeopleNumber = e.MaxPeopleNumber,
                Time = e.Time, Price = e.Price
            });
        }

        public EscapeRoomDto GetById(int id)
        {
            var escapeRoom = _escapeRoomRepository.FindById(id);
            return new EscapeRoomDto
            {
                Category = escapeRoom.Category, Description = escapeRoom.Description, Email = escapeRoom.Email,
                ForAdult = escapeRoom.ForAdult, MaxPeopleNumber = escapeRoom.MaxPeopleNumber,
                Name = escapeRoom.Name, OwnerId = escapeRoom.UserId, PhoneNumber = escapeRoom.PhoneNumber,
                Time = escapeRoom.Time, Price = escapeRoom.Price
            };
        }

        public void Add(NewEscapeRoomDto escapeRoom)
        {
            var newEscapeRoom = new EscapeRoom
            {
                Category = escapeRoom.Category, Description = escapeRoom.Description, Email = escapeRoom.Email,
                ForAdult = escapeRoom.ForAdult, MaxPeopleNumber = escapeRoom.MaxPeopleNumber,
                Name = escapeRoom.Name, PhoneNumber = escapeRoom.PhoneNumber, Price = escapeRoom.Price,
                Time = escapeRoom.Time
            };
            _escapeRoomRepository.Add(newEscapeRoom, escapeRoom.OwnerId);
        }


        public void Edit(int id, EditEscapeRoomDto escapeRoom)
        {
            var escapeRoomToEdit = new EscapeRoom()
            {
                Category = escapeRoom.Category, Description = escapeRoom.Description, Email = escapeRoom.Email,
                ForAdult = escapeRoom.ForAdult, MaxPeopleNumber = escapeRoom.MaxPeopleNumber, Name = escapeRoom.Name,
                PhoneNumber = escapeRoom.PhoneNumber, Price = escapeRoom.Price, Time = escapeRoom.Time
            };
            _escapeRoomRepository.Edit(id, escapeRoomToEdit);
        }

        public void Delete(int id)
        {
            _escapeRoomRepository.Remove(id);
        }

    }
}