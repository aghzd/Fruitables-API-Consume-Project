using Fruitables_FinalProject_MVC.Models.Basket;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using Fruitables_FinalProject_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fruitables_FinalProject_MVC.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketController(IBasketService basketService, IHttpContextAccessor httpContextAccessor)
        {
            _basketService = basketService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(new BasketVM()); 
            }

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var basket = await _basketService.GetBasketAsync(userId);

            var basketVM = new Basket
            {
                AppUserId = basket.AppUserId,
                Items = basket.Items.Select(bi => new BasketItem
                {
                    ProductId = bi.ProductId,
                    ProductName = bi.ProductName,
                    Quantity = bi.Quantity,
                    Price = bi.Price,
                    ImageUrl = bi.ImageUrl
                }).ToList()
            };

            return View(basketVM);


        }

        //[HttpPost]
        //public async Task<IActionResult> AddToBasket(int productId, int quantity)
        //{
        //    string userId = "123";
        //    var model = new AddBasketItem { UserId = userId, ProductId = productId, Quantity = quantity };
        //    await _basketService.AddToBasketAsync(model);

        //    return RedirectToAction("Index");
        //}

        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> AddToBasket(int productId)
        //{
        //    var dto = new AddBasketItem
        //    {
        //        ProductId = productId,
        //        Quantity = 1
        //    };

        //    var token = HttpContext.Session.GetString("JWToken");

        //    var client = _httpClientFactory.CreateClient();
        //    client.DefaultRequestHeaders.Authorization =
        //        new AuthenticationHeaderValue("Bearer", token);

        //    var response = await client.PostAsJsonAsync(
        //        "https://localhost:7178/api/Basket/AddToBasket/Add",
        //        dto
        //    );

        //    if (!response.IsSuccessStatusCode)
        //        return RedirectToAction("Error");

        //    return RedirectToAction("Index", "Basket");
        //}



        [HttpPost]
        public async Task<IActionResult> AddToBasket(int productId)
        {
            var result = await _basketService.AddToBasketAsync(productId);

            if (!result)
                return RedirectToAction("Error");

            return RedirectToAction("Index", "Basket");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromBasket(int productId)
        {
            string userId = "123";
            var model = new RemoveBasketItem { UserId = userId, ProductId = productId };
            await _basketService.RemoveFromBasketAsync(model);

            return RedirectToAction("Index");
        }
    }
}
