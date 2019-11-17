using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.DTOs.EscapeRooms
{
    [DataContract]
    public class EditEscapeRoomDto
    {
        [Required(ErrorMessage = "Id is required")]
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required"), MaxLength(30)]
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is required"), MaxLength(200)]
        [DataMember(IsRequired = true)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category is required in range 1 - 8"), Range(1,8)]
        [DataMember(IsRequired = true)]
        public Category Category { get; set; }

        [Required(ErrorMessage = "ForAdult is required")]
        [DataMember(IsRequired = true)]
        public bool ForAdult { get; set; }

        [Required(ErrorMessage = "Time is required")]
        [DataMember(IsRequired = true)]
        public int Time { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DataMember(IsRequired = true)]
        public double Price { get; set; }

        [Required(ErrorMessage = "MaxPeopleNumber is required")]
        [DataMember(IsRequired = true)]
        public int MaxPeopleNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required"), EmailAddress]
        [DataMember(IsRequired = true)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "PhoneNumber is required"), Phone]
        [DataMember(IsRequired = true)]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Street is required")]
        [DataMember(IsRequired = true)]
        public string Street { get; set; }

        [Required(ErrorMessage = "BuildingNumber is required")]
        [DataMember(IsRequired = true)]
        public int BuildingNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required")]
        [DataMember(IsRequired = true)]
        public string City { get; set; }
    }
}
