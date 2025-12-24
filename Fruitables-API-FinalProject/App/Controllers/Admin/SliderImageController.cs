using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.SliderImage;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace App.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class SliderImageController : ControllerBase
    {
        private readonly ISliderImageService _sliderImageService;
        public SliderImageController(ISliderImageService sliderImageService)
        {
            _sliderImageService = sliderImageService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SliderImageCreateDto request)
        {
            await _sliderImageService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), "Created Succesfully");
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
           
            try
            {
                var sliderImage = await _sliderImageService.GetByIdAsync(id);
                return Ok(sliderImage);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit( [FromRoute] int id , [FromForm] SliderImageEditDto request)
        {
         
            try
            {
                await _sliderImageService.EditAsync(id, request);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
           
            try
            {
                await _sliderImageService.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}