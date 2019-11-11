using System.ComponentModel.DataAnnotations;

namespace EscapeRoomCritic.Core.DTOs.Identity
{
    public class Credentials
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
