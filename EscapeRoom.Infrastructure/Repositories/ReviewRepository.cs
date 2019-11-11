using System.Collections.Generic;
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
