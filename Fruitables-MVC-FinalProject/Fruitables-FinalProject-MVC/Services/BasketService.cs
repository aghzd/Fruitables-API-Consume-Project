using Fruitables_FinalProject_MVC.Models.Basket;
using Fruitables_FinalProject_MVC.Services.Interfaces;

namespace Fruitables_FinalProject_MVC.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;

        public BasketService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:7178/");
        }

        public async Task<Basket> GetBasketAsync()
        {
            var res = await _client.GetAsync("api/Basket/Get");
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadFromJsonAsync<Basket>();
        }

        public async Task AddItemAsync(AddBasketItem dto)
        {
            await _client.PostAsJsonAsync("api/Basket/Add", dto);
        }

        public async Task DeleteItemAsync(int productId)
        {
            await _client.DeleteAsync($"api/Basket/Delete/{productId}");
        }

    }
}