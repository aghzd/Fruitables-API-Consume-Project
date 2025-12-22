using System.ComponentModel.DataAnnotations;

namespace Fruitables_FinalProject_MVC.Models.SliderInfo
{
    public class SliderInfoEdit
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile? BackgroundImage { get; set; }
    }
}
