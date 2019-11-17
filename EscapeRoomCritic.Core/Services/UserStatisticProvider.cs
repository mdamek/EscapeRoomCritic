using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.Services
{
    public class UserStatisticProvider : IUserStatisticProvider
    {
        public double CalculateAverageReviewLength(List<Review> reviews)
        {
            if (reviews.Count == 0) return 0;
            return reviews.Select(e => Convert.ToDouble(e.Content.Length)).Sum() / Convert.ToDouble(reviews.Count);
        }

        public double CalculateAverageRating(List<Review> reviews)
        {
            if (reviews.Count == 0) return 0;
            return Convert.ToDouble(reviews.Select(e => (int)e.Rating).Sum()) / Convert.ToDouble(reviews.Count);
        }

        public string FindFavoriteEscapeRoom(List<Review> reviews, List<EscapeRoom> escapeRooms)
        {
            var roomTypes = new Dictionary<string, int>();
            foreach (var review in reviews)
            {
                var type = escapeRooms.FirstOrDefault(e => e.EscapeRoomId == review.EscapeRoomId)?.Category.ToString();
                if (!roomTypes.ContainsKey(type ?? throw new InvalidOperationException("This review do not have escape room")))
                {
                    roomTypes.Add(type, 1);
                }
                else
                {
                    roomTypes[type] += 1;
                }
            }

            return roomTypes.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }
    }
}
