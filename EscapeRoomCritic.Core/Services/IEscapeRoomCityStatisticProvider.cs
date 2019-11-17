using System;
using System.Collections.Generic;
using System.Text;
using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.Services
{
    public interface IEscapeRoomCityStatisticProvider
    {
        double CalculateAveragePrice(List<EscapeRoom> escapeRooms);
        double CalculateAverageGameTime(List<EscapeRoom> escapeRooms);
        double CalculateAverageRating(List<EscapeRoom> escapeRooms, List<Review> ratings);
        Dictionary<string, int> CalculateFamousEscapeRoomsTypes(List<EscapeRoom> escapeRooms);
    }
}
