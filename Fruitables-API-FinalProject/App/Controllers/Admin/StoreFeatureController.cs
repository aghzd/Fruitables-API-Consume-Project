using Microsoft.AspNetCore.Mvc;
using Service.DTOs.StoreFeature;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace App.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class StoreFeatureController : ControllerBase
    {
        private readonly IStoreFeatureService _storeFeatureService;
        public StoreFeatureController(IStoreFeatureService storeFeatureService)
        {
            _storeFeatureService = storeFeatureService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StoreFeatureCreateDto request)
        {
            await _storeFeatureService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), "Created Succesfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var storeFeatures = await _storeFeatureService.GetAllAsync();
            return Ok(storeFeatures);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            
            try
            {
                var storeFeature = await _storeFeatureService.GetByIdAsync(id);
                return Ok(storeFeature);
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
                await _storeFeatureService.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] StoreFeatureEditDto request)
        {
            
            try
            {
                await _storeFeatureService.EditAsync(id, request);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}