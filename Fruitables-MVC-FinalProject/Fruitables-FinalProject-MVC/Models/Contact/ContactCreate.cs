using System.ComponentModel.DataAnnotations;

namespace Fruitables_FinalProject_MVC.Models.Contact
{
    public class ContactCreate
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