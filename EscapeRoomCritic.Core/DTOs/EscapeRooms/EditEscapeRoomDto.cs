using System.ComponentModel.DataAnnotations;
using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.DTOs.EscapeRooms
{
    public class EditEscapeRoomDto
    {
        [Required(ErrorMessage = "Name is required"), MaxLength(30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required"), MaxLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public Category Category { get; set; }
        [Required(ErrorMessage = "ForAdult is required")]
        public bool ForAdult { get; set; }
        [Required(ErrorMessage = "Time is required")]
        public int Time { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "MaxPeopleNumber is required")]
        public int MaxPeopleNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }
    }
}
