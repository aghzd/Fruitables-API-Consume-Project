using Fruitables_FinalProject_MVC.Models.Basket;

namespace Fruitables_FinalProject_MVC.Services.Interfaces
{
    public interface IBasketService
    {
        Task<Basket> GetBasketAsync();
        Task AddItemAsync(AddBasketItem dto);
        Task DeleteItemAsync(int productId);
    }
}