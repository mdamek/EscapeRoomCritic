using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.DTOs.Reviews
{
    public class ReviewDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Rating Rating { get; set; }
    }
}
