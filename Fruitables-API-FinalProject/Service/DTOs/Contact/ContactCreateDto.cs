using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.Contact
{
    public class ContactCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email adress")]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}