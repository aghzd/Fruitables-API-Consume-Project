using Microsoft.AspNetCore.Http;

namespace Service.DTOs.SliderInfo
{
    public class SliderInfoCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile BackgroundImage { get; set; }
    }
}