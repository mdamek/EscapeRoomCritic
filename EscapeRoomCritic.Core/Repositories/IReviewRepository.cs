using System.Collections.Generic;
using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.Repositories
{
    public interface IReviewRepository
    {
        void Add(Review review);       
        void Remove(int reviewId);
        IEnumerable<Review> GetReviews();
    }
}
