using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.DTOs.Reviews
{
    public class ReviewForEscapeRoomDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Rating Rating { get; set; }
        public string Author { get; set; }
    }
}
