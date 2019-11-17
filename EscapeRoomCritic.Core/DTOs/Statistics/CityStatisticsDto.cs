using System.Collections.Generic;

namespace EscapeRoomCritic.Core.DTOs.Statistics
{
    public class CityStatisticsDto
    {
        public int EscapeRoomsNumber { get; set; }
        public double AveragePrice { get; set; }
        public double AverageGameTime { get; set; }
        public double AverageRating { get; set; }
        public Dictionary<string, int> FamousTypes { get; set; }
    }
}
