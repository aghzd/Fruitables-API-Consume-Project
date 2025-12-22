using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.SliderImage
{
    public class SliderImageCreateDto
    {
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}