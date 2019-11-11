namespace EscapeRoomCritic.Core.Models
{
    public class EscapeRoom
    {
        public int EscapeRoomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public bool ForAdult { get; set; }
        public int Time { get; set; }
        public double Price { get; set; }
        public int MaxPeopleNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        public User Owner { get; set; }
    }
}
