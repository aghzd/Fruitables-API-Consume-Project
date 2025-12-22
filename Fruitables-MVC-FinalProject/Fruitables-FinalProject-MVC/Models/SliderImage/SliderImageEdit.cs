using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Fruitables_FinalProject_MVC.Models.SliderImage
{
    public class SliderImageEdit
    {
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public IFormFile? Image { get; set; } 
    }
}