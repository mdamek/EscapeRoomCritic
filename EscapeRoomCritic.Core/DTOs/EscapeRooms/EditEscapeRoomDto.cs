using System.ComponentModel.DataAnnotations;
using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.DTOs.EscapeRooms
{
    public class EditEscapeRoomDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required"), MaxLength(30)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is required"), MaxLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Category is required in range 1 - 8"), Range(1,8)]
        public Category Category { get; set; }
        [Required(ErrorMessage = "ForAdult is required")]
        public bool ForAdult { get; set; }
        [Required(ErrorMessage = "Time is required")]
        public int Time { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "MaxPeopleNumber is required")]
        public int MaxPeopleNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "PhoneNumber is required"), Phone]
        public string PhoneNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Street is required")]
        public string Street { get; set; }
        [Required(ErrorMessage = "BuildingNumber is required")]
        public int BuildingNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required")]
        public string City { get; set; }
    }
}
