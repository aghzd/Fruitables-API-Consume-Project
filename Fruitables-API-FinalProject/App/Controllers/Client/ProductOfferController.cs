using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace App.Controllers.Client
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductOfferController : ControllerBase
    {
        private readonly IProductOfferService _service;
        public ProductOfferController(IProductOfferService service)
        {
            _service = service;
        }

         [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productOffers = await _service.GetAllAsync();
            return Ok(productOffers);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var productOffer = await _service.GetByIdAsync(id);
            return Ok(productOffer);
        }
    }
}