using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace App.Controllers.Client
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SliderInfoController : ControllerBase
    {
        private readonly ISliderInfoService _sliderInfoService;
        public SliderInfoController(ISliderInfoService sliderInfoService)
        {
            _sliderInfoService = sliderInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sliderInfos = await _sliderInfoService.GetAllAsync();
            return Ok(sliderInfos);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var sliderInfo = await _sliderInfoService.GetByIdAsync(id);
            return Ok(sliderInfo);
        }
    }
}