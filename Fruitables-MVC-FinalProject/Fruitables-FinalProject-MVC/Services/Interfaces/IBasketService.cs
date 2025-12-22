using Fruitables_FinalProject_MVC.Models.Basket;

namespace Fruitables_FinalProject_MVC.Services.Interfaces
{
    public interface IBasketService
    {
        Task<Basket> GetBasketAsync(string userId);
        //Task AddToBasketAsync(AddBasketItem model);
        Task<bool> AddToBasketAsync(int productId);
        Task RemoveFromBasketAsync(RemoveBasketItem model);
    }
}