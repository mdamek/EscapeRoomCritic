using System.Collections.Generic;
using EscapeRoomCritic.Core.DTOs.EscapeRooms;

namespace EscapeRoomCritic.Core.Services
{
    public interface IEscapeRoomService
    {
        IEnumerable<EscapeRoomDto> GetAll();
        EscapeRoomDto GetById(int id);
        void Add(NewEscapeRoomDto escapeRoom);
        void Edit(EditEscapeRoomDto escapeRoom);
        void Delete(int id);
    }
}
