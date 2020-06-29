using System.ComponentModel.DataAnnotations;

namespace BirthdayCardGenerator.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool? WillAttend { get; set; }
    }
}
