namespace EscapeRoomCritic.Core.DTOs.Statistics
{
    public class UserStatisticsDto
    {
        public int ReviewsNumber { get; set; }
        public double AverageRating { get; set; }
        public string FavoriteEscapeRoomType { get; set; }
        public double AverageReviewLength { get; set; }
    }
}
