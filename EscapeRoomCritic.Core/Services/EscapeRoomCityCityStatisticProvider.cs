using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.Services
{
    public class EscapeRoomCityCityStatisticProvider : IEscapeRoomCityStatisticProvider
    {
        public double CalculateAveragePrice(List<EscapeRoom> escapeRooms)
        {
            return escapeRooms.Select(e => e.Price).Sum() / Convert.ToDouble(escapeRooms.Count);
        }

        public double CalculateAverageGameTime(List<EscapeRoom> escapeRooms)
        {
            return Convert.ToDouble(escapeRooms.Select(e => e.Time).Sum()) / Convert.ToDouble(escapeRooms.Count);
        }

        public double CalculateAverageRating(List<EscapeRoom> escapeRooms, List<Review> ratings)
        {
            var ratingsForActualEscapeRooms =
                ratings.Where(e => escapeRooms.Any(a => a.EscapeRoomId == e.EscapeRoomId)).ToList();
            if (ratingsForActualEscapeRooms.Count == 0) return 0;
            return Convert.ToDouble(ratingsForActualEscapeRooms.Select(e => (int)e.Rating).Sum()) / Convert.ToDouble(ratingsForActualEscapeRooms.Count);
        }

        public Dictionary<string, int> CalculateFamousEscapeRoomsTypes(List<EscapeRoom> escapeRooms)
        {
            var roomTypes = new Dictionary<string, int>();
            foreach (var escapeRoom in escapeRooms)
            {
                var type = escapeRoom.Category.ToString();
                if (!roomTypes.ContainsKey(type))
                {
                    roomTypes.Add(type, 1);
                }
                else
                {
                    roomTypes[type] += 1;
                }
            }
            return roomTypes.OrderBy(e => e.Value).ToDictionary(room => room.Key, room => room.Value);
        }
    }
}
