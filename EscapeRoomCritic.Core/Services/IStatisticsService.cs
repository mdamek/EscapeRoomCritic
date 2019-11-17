using EscapeRoomCritic.Core.DTOs.Statistics;

namespace EscapeRoomCritic.Core.Services
{
    public interface IStatisticsService
    {
        CityStatisticsDto GetForCityEscapeRoomsStatistics(string city);
        UserStatisticsDto GetForUserStatistics(int userId);
        EscapeRoomStatisticsDto GetForEscapeRoomStatistics(int escapeRoomId);
    }
}
