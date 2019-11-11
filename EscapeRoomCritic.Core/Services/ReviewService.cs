using System.Collections.Generic;
using System.Linq;
using EscapeRoomCritic.Core.DTOs.Reviews;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Repositories;

namespace EscapeRoomCritic.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public IEnumerable<ReviewDto> GetByRoomId(int id)
        {
            var allReviews = _reviewRepository.GetReviews();
            return allReviews.ToList().Where(e => e.EscapeRoomId == id).ToList().ConvertAll(e =>
                new ReviewDto {Content = e.Content, Rating = e.Rating, Title = e.Title});
        }

        public IEnumerable<ReviewDto> GetByUserId(int id)
        {
            var allReviews = _reviewRepository.GetReviews();
            return allReviews.ToList().Where(e => e.UserId == id).ToList().ConvertAll(e =>
                new ReviewDto { Content = e.Content, Rating = e.Rating, Title = e.Title });
        }

        public void Add(NewReviewDto review)
        {
            var newReview = new Review
            {
                Content = review.Content, Title = review.Title, Rating = review.Rating,
                EscapeRoomId = review.EscapeRoomId, UserId = review.UserId
            };
            _reviewRepository.Add(newReview);
        }

        public void Delete(int id)
        {
            _reviewRepository.Remove(id);
        }
    }
}
