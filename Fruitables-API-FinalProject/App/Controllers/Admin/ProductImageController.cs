using Microsoft.AspNetCore.Mvc;
using Service.DTOs.ProductImage;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace App.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _service;
        public ProductImageController(IProductImageService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductImageCreateDto request)
        {
            await _service.CreateAsync(request);
            return CreatedAtAction(nameof(Create), "Created Succesfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit( [FromRoute] int id, [FromForm] ProductImageEditDto request)
        {
            
            try
            {
                await _service.EditAsync(id, request);
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
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productImages = await _service.GetAllAsync();
            return Ok(productImages);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
           
            try
            {
                var productImage = await _service.GetByIdAsync(id);
                return Ok(productImage);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}