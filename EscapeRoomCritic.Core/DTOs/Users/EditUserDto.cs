using System.ComponentModel.DataAnnotations;

namespace EscapeRoomCritic.Core.DTOs.Users
{
    public class EditUserDto
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Role is required")]
        public string Role { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }


}
