using System.Collections.Generic;
using System.Linq;
using EscapeRoomCritic.Core.Exceptions;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Repositories;

namespace EscapeRoomCritic.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly EscapeRoomCriticDbContext _dbContext;

        public ReviewRepository(EscapeRoomCriticDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Review review)
        {
            var user = _dbContext.Users.FirstOrDefault(e => e.UserId == review.UserId);
            if(user == null) throw new CanNotFindValueException($"User with {review.UserId} id do not exist");
            var escapeRoom = _dbContext.EscapeRooms.FirstOrDefault(e => e.EscapeRoomId == review.EscapeRoomId);
            if (escapeRoom == null) throw new CanNotFindValueException($"Escape room with {review.EscapeRoomId} id do not exist");
            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
        }

        public void Remove(int reviewId)
        {
            var review = _dbContext.Reviews.Find(reviewId);
            _dbContext.Reviews.Remove(review);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Review> GetReviews()
        {
            return _dbContext.Reviews;
        }
    }
}
