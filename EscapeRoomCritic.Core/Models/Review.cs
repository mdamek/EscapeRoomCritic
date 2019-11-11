namespace EscapeRoomCritic.Core.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Rating Rating { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int EscapeRoomId { get; set; }
        public EscapeRoom EscapeRoom { get; set; }
    }
}
