using Fruitables_FinalProject_MVC.Services.Interfaces;
using Fruitables_FinalProject_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fruitables_FinalProject_MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _service;

        public BasketController(IBasketService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var basket = await _service.GetBasketAsync();
            var model = new BasketVM
            {
                Basket = basket
            };
            return View(model);
        }
    }
}