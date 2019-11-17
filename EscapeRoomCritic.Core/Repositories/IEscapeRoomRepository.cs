using System.Collections.Generic;
using EscapeRoomCritic.Core.DTOs.EscapeRooms;
using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.Repositories
{
    public interface IEscapeRoomRepository
    {
        void Add(EscapeRoom escapeRoom);
        void Edit(EditEscapeRoomDto escapeRoom);
        void Remove(int escapeRoomId);
        IEnumerable<EscapeRoom> GetEscapeRooms();
        EscapeRoom FindById(int escapeRoomId);
    }
}
