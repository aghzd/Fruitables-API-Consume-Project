using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace App.Controllers.Client
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatsCardController : ControllerBase
    {
        private readonly IStatsCardService _statsCardService;
        public StatsCardController(IStatsCardService statsCardService)
        {
            _statsCardService = statsCardService;
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
            var statsCard = await _statsCardService.GetById(id);
            return Ok(statsCard);
        }
    }
}