using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace App.Controllers.Client
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreFeatureController : ControllerBase
    {
        private readonly IStoreFeatureService _storeFeatureService;
        public StoreFeatureController(IStoreFeatureService storeFeatureService)
        {
            _storeFeatureService = storeFeatureService;
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
            var storeFeature = await _storeFeatureService.GetByIdAsync(id);
            return Ok(storeFeature);
        }
    }
}