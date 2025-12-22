using System.ComponentModel.DataAnnotations;

namespace Fruitables_FinalProject_MVC.Models.SliderImage
{
    public class SliderImageCreate
    {
        [Required]
        public string CategoryName { get; set; } 
        [Required]
        public IFormFile Image { get; set; }
        public bool IsActive { get; set; }
    }
}