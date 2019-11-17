using System;
using System.Collections.Generic;
using System.Text;
using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.Services
{
    public interface IUserStatisticProvider
    {
        double CalculateAverageRating(List<Review> reviews);
        double CalculateAverageReviewLength(List<Review> reviews);
        string FindFavoriteEscapeRoom(List<Review> reviews, List<EscapeRoom> escapeRooms);
    }
}
