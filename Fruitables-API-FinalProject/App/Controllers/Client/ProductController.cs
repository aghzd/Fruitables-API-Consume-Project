using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace App.Controllers.Client
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var product = await _service.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string search)
        {
            var products = await _service.SearchAsync(search);
            return Ok(products);
        }


        [HttpGet]
        public async Task<IActionResult> Sort([FromQuery] int price)
        {
            var products = await _service.SortByPriceAsync(price);
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> PaginatedDatas([FromQuery] int page)
        {
            var products = await _service.GetPaginatedDatas(page);
            return Ok(products);
        }
    }
}