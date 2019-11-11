
using System.Collections.Generic;

namespace EscapeRoomCritic.Core.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<EscapeRoom> EscapeRooms { get; set; } = new List<EscapeRoom>();
    }
}
