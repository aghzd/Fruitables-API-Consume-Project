using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.StatsCard;
using Service.Helpers.Exceptions;
using Service.Services;
using Service.Services.Interfaces;

namespace App.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StatsCardController : ControllerBase
    {
        private readonly IStatsCardService _statsCardService;
        public StatsCardController(IStatsCardService statsCardService)
        {
            _statsCardService = statsCardService;
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create([FromBody] StatsCardCreateDto request)
        {
            await _statsCardService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), "Created Succesfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var statsCards = await _statsCardService.GetAllAsync();
            return Ok(statsCards);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
          
            try
            {
                var statsCard = await _statsCardService.GetById(id);
                return Ok(statsCard);
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
                await _statsCardService.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id,StatsCardEditDto request)
        {
         
            try
            {
                await _statsCardService.EditAsync(id, request);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}