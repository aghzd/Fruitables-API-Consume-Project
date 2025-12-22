using Microsoft.AspNetCore.Mvc;
using Service.DTOs.SliderInfo;
using Service.Helpers.Exceptions;
using Service.Services;
using Service.Services.Interfaces;

namespace App.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class SliderInfoController : ControllerBase
    {
        private readonly ISliderInfoService _sliderInfoService;
        public SliderInfoController(ISliderInfoService sliderInfoService)
        {
            _sliderInfoService = sliderInfoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SliderInfoCreateDto request)
        {
            await _sliderInfoService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), "Created Succesfully");
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
          
            try
            {
                var sliderInfo = await _sliderInfoService.GetByIdAsync(id);
                return Ok(sliderInfo);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] SliderInfoEditDto request)
        {
         
            try
            {
                await _sliderInfoService.EditAsync(id, request);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
          
            try
            {
                await _sliderInfoService.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}