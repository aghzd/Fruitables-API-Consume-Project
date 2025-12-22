using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Basket;
using Service.Services.Interfaces;

namespace App.Controllers.Client
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBasketItemDto dto)
        {
            var cookieKey = GetOrCreateBasketCookie();
            await _basketService.AddItemAsync(cookieKey, dto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cookieKey = GetOrCreateBasketCookie();
            var basket = await _basketService.GetBasketAsync(cookieKey);
            return Ok(basket);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cookieKey = GetOrCreateBasketCookie();
            await _basketService.DeleteItemAsync(cookieKey, id);
            return Ok();
        }

        private string GetOrCreateBasketCookie()
        {
            const string cookieName = "basket_key";

            if (!Request.Cookies.ContainsKey(cookieName))
            {
                var key = Guid.NewGuid().ToString();
                Response.Cookies.Append(cookieName, key, new CookieOptions
                {
                    HttpOnly = true,
                    IsEssential = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                });
                return key;
            }

            return Request.Cookies[cookieName];
        }
    }
}