using System;
using System.Collections.Generic;
using System.Linq;
using EscapeRoomCritic.Core.DTOs.Statistics;
using EscapeRoomCritic.Core.Exceptions;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Repositories;

namespace EscapeRoomCritic.Core.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEscapeRoomRepository _escapeRoomRepository;
        private readonly IEscapeRoomCityStatisticProvider _escapeRoomCityStatisticProvider;
        private readonly IUserStatisticProvider _userStatisticProvider;

        public StatisticsService(IReviewRepository reviewRepository, IUserRepository userRepository,
            IEscapeRoomRepository escapeRoomRepository, IEscapeRoomCityStatisticProvider escapeRoomCityStatisticProvider, IUserStatisticProvider userStatisticProvider)
        {
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
            _escapeRoomRepository = escapeRoomRepository;
            _escapeRoomCityStatisticProvider = escapeRoomCityStatisticProvider;
            _userStatisticProvider = userStatisticProvider;
        }

        public CityStatisticsDto GetForCityEscapeRoomsStatistics(string city)
        {
            var escapeRooms = _escapeRoomRepository.GetEscapeRooms().Where(e => e.City == city).ToList();
            if (!escapeRooms.Any()) throw new BadValueException("Escape rooms for this city does not exists");
            var reviews = _reviewRepository.GetReviews().ToList();

            return new CityStatisticsDto
            {
                EscapeRoomsNumber = escapeRooms.Count,
                AverageGameTime = _escapeRoomCityStatisticProvider.CalculateAverageGameTime(escapeRooms),
                AveragePrice = _escapeRoomCityStatisticProvider.CalculateAveragePrice(escapeRooms),
                AverageRating = _escapeRoomCityStatisticProvider.CalculateAverageRating(escapeRooms, reviews),
                FamousTypes = _escapeRoomCityStatisticProvider.CalculateFamousEscapeRoomsTypes(escapeRooms)
            };
        }

        public UserStatisticsDto GetForUserStatistics(int userId)
        {
            _userRepository.FindById(userId);
            var reviews = _reviewRepository.GetReviews().Where(e => e.UserId == userId).ToList();
            var escapeRooms = _escapeRoomRepository.GetEscapeRooms().ToList();
            return new UserStatisticsDto
            {
                AverageRating = _userStatisticProvider.CalculateAverageRating(reviews),
                AverageReviewLength = _userStatisticProvider.CalculateAverageReviewLength(reviews),
                ReviewsNumber = reviews.Count,
                FavoriteEscapeRoomType = _userStatisticProvider.FindFavoriteEscapeRoom(reviews, escapeRooms),
            };
        }

        public EscapeRoomStatisticsDto GetForEscapeRoomStatistics(int escapeRoomId)
        {
            var escapeRoom = _escapeRoomRepository.FindById(escapeRoomId);
            var reviews = _reviewRepository.GetReviews().Where(e => e.EscapeRoomId == escapeRoom.EscapeRoomId).ToList();
            return new EscapeRoomStatisticsDto
            {
                AverageRating = Convert.ToDouble(reviews.Select(e => (int)e.Rating).Sum()) /
                                Convert.ToDouble(reviews.Count)
            };
        }

        

       

        
    }
}
