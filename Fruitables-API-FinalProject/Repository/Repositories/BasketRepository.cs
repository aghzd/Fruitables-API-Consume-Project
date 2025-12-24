using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BasketRepository : BaseRepository<Basket>, IBasketRepository
    {
        public BasketRepository(AppDbContext context) : base(context) { }

        public async Task<Basket> GetBasketAsync(string cookieKey)
        {
            return await _context.Baskets
                .Include(b => b.BasketItems)
                .ThenInclude(bi => bi.Product)
                .ThenInclude(bi=>bi.ProductImages)
                .FirstOrDefaultAsync(b => b.CookieKey == cookieKey);
        }

        public async Task AddItemAsync(string cookieKey, int productId, int quantity)
        {
            var basket = await GetBasketAsync(cookieKey);

            if (basket == null)
            {
                basket = new Basket { CookieKey = cookieKey };
                _context.Baskets.Add(basket);
                await _context.SaveChangesAsync();
            }

            var item = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
                item.Quantity += quantity;
            else
                basket.BasketItems.Add(new BasketItem
                {
                    ProductId = productId,
                    Quantity = quantity
                });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(string cookieKey, int productId)
        {
            var basket = await GetBasketAsync(cookieKey);
            if (basket == null) return;

            var item = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            if (item == null) return;

            _context.BasketItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}