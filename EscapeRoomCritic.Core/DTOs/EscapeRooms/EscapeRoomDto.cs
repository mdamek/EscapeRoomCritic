using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.DTOs
{
    public class EscapeRoomDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public bool ForAdult { get; set; }
        public int Time { get; set; }
        public double Price { get; set; }
        public int MaxPeopleNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int OwnerId { get; set; }
    }
}
