using System.Collections.Generic;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Services;
using NUnit.Framework;

namespace EscapeRoomCritic.Tests.UnitTests
{
    public class StatisticsTests
    {
        private IUserStatisticProvider _userStatisticProvider;
        private IEscapeRoomCityStatisticProvider _cityStatisticProvider;

        [OneTimeSetUp]
        public void Setup()
        {
            _userStatisticProvider = new UserStatisticProvider();
            _cityStatisticProvider = new EscapeRoomCityCityStatisticProvider();
        }

        [Test]
        public void Should_Calculate_Average_Rating_Of_Reviews()
        {
            var reviews = new List<Review>
            {
                new Review
                {
                    Rating = Rating.Five
                },
                new Review
                {
                    Rating = Rating.Seven
                },
                new Review
                {
                    Rating = Rating.Two
                },
                new Review
                {
                    Rating = Rating.Ten
                }
            };
            var average = _userStatisticProvider.CalculateAverageRating(reviews);
            Assert.AreEqual(6, average);
        }

        [Test]
        public void Should_Return_0_Rating_Of_Reviews_For_Empty_Reviews()
        {
            var reviews = new List<Review>();
            var average = _userStatisticProvider.CalculateAverageRating(reviews);
            Assert.AreEqual(0, average);
        }

        [Test]
        public void Should_Calculate_Average_Description_Length()
        {
            var reviews = new List<Review>
            {
                new Review {Content = "TEST CONTENT"},
                new Review {Content = "EXAMPLE CONTENT1"}
            };
            var average = _userStatisticProvider.CalculateAverageReviewLength(reviews);
            Assert.AreEqual(14, average);
        }

        [Test]
        public void Should_Find_Favorite_Escape_Room()
        {
            var escapeRooms = new List<EscapeRoom>
            {
                new EscapeRoom
                {
                    EscapeRoomId = 1,
                    Category = Category.Abstract
                },
                new EscapeRoom
                {
                    EscapeRoomId = 2,
                    Category = Category.Abstract
                },
                new EscapeRoom
                {
                    EscapeRoomId = 3,
                    Category = Category.Criminal
                },
                new EscapeRoom
                {
                    EscapeRoomId = 4,
                    Category = Category.Horror
                }
            };

            var reviews = new List<Review>
            {
                new Review
                {
                    EscapeRoomId = 1,
                    Rating = Rating.Eight
                },
                new Review
                {
                    EscapeRoomId = 2,
                    Rating = Rating.Nine
                },
                new Review
                {
                    EscapeRoomId = 3,
                    Rating = Rating.Eight
                },
                new Review
                {
                    EscapeRoomId = 4,
                    Rating = Rating.Nine
                },

            };

            var favoriteEscapeRoom = _userStatisticProvider.FindFavoriteEscapeRoom(reviews, escapeRooms);
            Assert.AreEqual("Abstract", favoriteEscapeRoom);
        }

        [Test]
        public void Should_Calculate_Average_Game_Time()
        {
            var escapeRooms = new List<EscapeRoom>
            {
                new EscapeRoom {Time = 60},
                new EscapeRoom {Time = 60},
                new EscapeRoom {Time = 60},
                new EscapeRoom {Time = 90}
            };
            var averageGameTime = _cityStatisticProvider.CalculateAverageGameTime(escapeRooms);
            Assert.AreEqual(67.5, averageGameTime);
        }

        [Test]
        public void Should_Calculate_Average_Price()
        {
            var escapeRooms = new List<EscapeRoom>
            {
                new EscapeRoom {Price = 150},
                new EscapeRoom {Price = 150},
                new EscapeRoom {Price = 200},
                new EscapeRoom {Price = 100}
            };
            var averageGameTime = _cityStatisticProvider.CalculateAveragePrice(escapeRooms);
            Assert.AreEqual(150, averageGameTime);
        }

        [Test]
        public void Should_Calculate_Average_Rating()
        {
            var escapeRooms = new List<EscapeRoom>
            {
                new EscapeRoom {EscapeRoomId = 1},
                new EscapeRoom {EscapeRoomId = 2},
                new EscapeRoom {EscapeRoomId = 3},
                new EscapeRoom {EscapeRoomId = 4}
            };
            var reviews = new List<Review>
            {
                new Review {EscapeRoomId = 1, Rating = Rating.Five},
                new Review {EscapeRoomId = 3, Rating = Rating.Ten},
                new Review {EscapeRoomId = 3, Rating = Rating.Zero}

            };
            var averageRating = _cityStatisticProvider.CalculateAverageRating(escapeRooms, reviews);
            Assert.AreEqual(5, averageRating);
        }

        [Test]
        public void Should_Provide_Famous_Escape_Rooms_In_Order()
        {
            var escapeRooms = new List<EscapeRoom>
            {
                new EscapeRoom {Category = Category.Adventure},
                new EscapeRoom {Category = Category.Adventure},
                new EscapeRoom {Category = Category.Adventure},
                new EscapeRoom {Category = Category.Adventure},
                new EscapeRoom {Category = Category.Abstract},
                new EscapeRoom {Category = Category.Abstract},
                new EscapeRoom {Category = Category.Abstract},
                new EscapeRoom {Category = Category.Fantasy},
                new EscapeRoom {Category = Category.Fantasy},
                new EscapeRoom {Category = Category.Criminal},
                new EscapeRoom {Category = Category.Thriller}

            };
            var famousEscapeRooms = _cityStatisticProvider.CalculateFamousEscapeRoomsTypes(escapeRooms);

            Assert.AreEqual(4, famousEscapeRooms[Category.Adventure.ToString()]);
            Assert.AreEqual(3, famousEscapeRooms[Category.Abstract.ToString()]);
            Assert.AreEqual(2, famousEscapeRooms[Category.Fantasy.ToString()]);
            Assert.AreEqual(1, famousEscapeRooms[Category.Criminal.ToString()]);
            Assert.AreEqual(1, famousEscapeRooms[Category.Thriller.ToString()]);
        }

    }
}