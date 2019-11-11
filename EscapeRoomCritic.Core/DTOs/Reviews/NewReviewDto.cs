using System.ComponentModel.DataAnnotations;
using EscapeRoomCritic.Core.Models;

namespace EscapeRoomCritic.Core.DTOs.Reviews
{
    public class NewReviewDto
    {
        [Required(ErrorMessage = "Title is required"), MaxLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is required"), MaxLength(300)]
        public string Content { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        public Rating Rating { get; set; }
        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "EscapeRoomId is required")]
        public int EscapeRoomId { get; set; }
    }
}
