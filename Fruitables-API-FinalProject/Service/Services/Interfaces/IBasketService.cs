using Domain.Entities;
using Service.DTOs.Basket;

namespace Service.Services.Interfaces
{
    public interface IBasketService
    {
        //Task<Basket> GetBasketAsync(string cookieKey);
        Task<BasketDto> GetBasketAsync(string cookieKey);
        Task AddItemAsync(string cookieKey, AddBasketItemDto dto);
        Task DeleteItemAsync(string cookieKey, int productId);
    }
}