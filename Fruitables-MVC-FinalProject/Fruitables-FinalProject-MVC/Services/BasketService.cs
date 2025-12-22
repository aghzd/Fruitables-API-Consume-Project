using Fruitables_FinalProject_MVC.Models.Basket;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;

namespace Fruitables_FinalProject_MVC.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketService(HttpClient httpClient,
                             IHttpContextAccessor contextAccessor,
                             IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
            _httpClientFactory = httpClientFactory;
        }


        public async Task<bool> AddToBasketAsync(int productId)
        {
            var basketItem = new AddBasketItem
            {
                ProductId = productId,
                Quantity = 1
            };

            var token = _contextAccessor
                .HttpContext?
                .Session
                .GetString("JWToken");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsJsonAsync(
                "https://localhost:5001/api/basket/addtobasket",
                basketItem
            );

            return response.IsSuccessStatusCode;
        }

        public async Task<Basket> GetBasketAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));

            var requestUrl = $"https://localhost:7178/api/Basket/GetBasket/{userId}";

            //var token = _contextAccessor.HttpContext?.Session?.GetString("AuthToken");
            //if (!string.IsNullOrEmpty(token))
            //{
            //    _httpClient.DefaultRequestHeaders.Authorization =
            //        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            //}


            var response = await _httpClient.GetAsync(requestUrl);

            if (response.StatusCode == HttpStatusCode.NotFound ||
                response.StatusCode == HttpStatusCode.NoContent)
            {
                return new Basket
                {
                    AppUserId = userId,
                    Items = new List<BasketItem>()
                };
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    $"Failed to retrieve basket. StatusCode: {response.StatusCode}");
            }

            var basket = await response.Content.ReadFromJsonAsync<Basket>();

            return basket ?? new Basket
            {
                AppUserId = userId,
                Items = new List<BasketItem>()
            };
        }


        //public async Task AddToBasketAsync(AddBasketItem model)
        //{
        //    await _httpClient.PostAsJsonAsync("https://localhost:7178/api/Basket/AddToBasket/Add", model);
        //}




        public async Task RemoveFromBasketAsync(RemoveBasketItem model)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7178/api/Basket/RemoveFromBasket/Remove", model);
        }
    }
}