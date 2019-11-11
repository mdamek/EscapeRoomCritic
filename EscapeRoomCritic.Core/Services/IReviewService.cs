using System.Collections.Generic;
using EscapeRoomCritic.Core.DTOs.Reviews;

namespace EscapeRoomCritic.Core.Services
{
    public interface IReviewService
    {
        IEnumerable<ReviewDto> GetByRoomId(int roomId);
        IEnumerable<ReviewDto> GetByUserId(int userId);
        void Add(NewReviewDto review);
        void Delete(int id);
    }
}
