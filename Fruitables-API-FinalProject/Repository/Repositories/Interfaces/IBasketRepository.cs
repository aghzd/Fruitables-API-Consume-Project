using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IBasketRepository : IBaseRepository<Basket>
    {
        Task<Basket> GetBasketAsync(string cookieKey);
        Task AddItemAsync(string cookieKey, int productId, int quantity);
        Task DeleteItemAsync(string cookieKey, int productId);
    }
}