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
        private readonly IUserRepository _userRepository;
        private readonly IEscapeRoomRepository _escapeRoomRepository;

        public ReviewService(IReviewRepository reviewRepository, IUserRepository userRepository,
            IEscapeRoomRepository escapeRoomRepository)
        {
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
            _escapeRoomRepository = escapeRoomRepository;
        }

        public IEnumerable<ReviewForEscapeRoomDto> GetByRoomId(int id)
        {
            var allReviews = _reviewRepository.GetReviews();
            var users = _userRepository.GetUsers();
            return allReviews.ToList().Where(e => e.EscapeRoomId == id).ToList().ConvertAll(e =>
                new ReviewForEscapeRoomDto
                {
                    Content = e.Content, Rating = e.Rating, Title = e.Title,
                    Author = users.FirstOrDefault(a => a.UserId == e.UserId)?.Username, Id = e.Id
                });
        }

        public IEnumerable<ReviewForUserDto> GetByUserId(int id)
        {
            var allReviews = _reviewRepository.GetReviews();
            var escapeRooms = _escapeRoomRepository.GetEscapeRooms();
            return allReviews.ToList().Where(e => e.UserId == id).ToList().ConvertAll(e =>
                new ReviewForUserDto
                {
                    Content = e.Content, Rating = e.Rating, Title = e.Title,
                    EscapeRoom = escapeRooms.FirstOrDefault(a => a.EscapeRoomId == e.EscapeRoomId)?.Name, Id = e.Id
                });
        }

        public void Add(NewReviewDto review)
        {
            ValidateRating(review.Rating);
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

        private bool ValidateRating(Rating rating)
        {
            var asdd = rating;
            return true;
        }
    }
}
