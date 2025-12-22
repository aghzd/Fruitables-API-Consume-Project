using System.ComponentModel.DataAnnotations;

namespace Fruitables_FinalProject_MVC.Models.Account
{
    public class Login
    {
        [Required(ErrorMessage = "Email Or Username is required")]
        public string EmailOrUserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}