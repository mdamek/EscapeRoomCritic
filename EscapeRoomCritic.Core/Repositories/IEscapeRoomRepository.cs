using System.Collections.Generic;
using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.Repositories
{
    public interface IEscapeRoomRepository
    {
        void Add(EscapeRoom escapeRoom, int userId);
        EscapeRoom Edit(int id, EscapeRoom escapeRoom);
        void Remove(int escapeRoomId);
        IEnumerable<EscapeRoom> GetEscapeRooms();
        EscapeRoom FindById(int escapeRoomId);
    }
}
