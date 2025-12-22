using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace App.Controllers.Client
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SliderImageController : ControllerBase
    {
        private readonly ISliderImageService _sliderImageService;
        public SliderImageController(ISliderImageService sliderImageService)
        {
            _sliderImageService = sliderImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sliderImages = await _sliderImageService.GetAllAsync();
            return Ok(sliderImages);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var sliderImage = await _sliderImageService.GetByIdAsync(id);
            return Ok(sliderImage);
        }
    }
}