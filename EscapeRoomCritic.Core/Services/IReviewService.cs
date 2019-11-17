using System.Collections.Generic;
using EscapeRoomCritic.Core.DTOs.Reviews;

namespace EscapeRoomCritic.Core.Services
{
    public interface IReviewService
    {
        IEnumerable<ReviewForEscapeRoomDto> GetByRoomId(int roomId);
        IEnumerable<ReviewForUserDto> GetByUserId(int userId);
        void Add(NewReviewDto review);
        void Delete(int id);
    }
}
