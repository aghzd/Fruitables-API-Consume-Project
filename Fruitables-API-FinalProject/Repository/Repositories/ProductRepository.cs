using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    internal class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetAllWithImages()
        {
            var products = await _context.Products.Include(p => p.Category)
                                                  .Include(p => p.ProductImages).ToListAsync();
            return products;
        }

        public async Task<Product> GetByIdWithImages(int id)
        {
            var product = await _context.Products.Include(p => p.Category)
                                                 .Include(p => p.ProductImages).FirstOrDefaultAsync(p=>p.Id==id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetPaginatedDatas(int page, int take = 3)
        {
            var products = await _context.Products.Skip((page*take)-take).Take(take).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> SearchAsync(string search)
        {
            var products = await _context.Products.Where(p => p.Name.Trim().ToLower().Contains(search.Trim().ToLower())
                                                           || p.Description.Trim().ToLower().Contains(search.Trim().ToLower())).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> SortByPriceAsync(int price)
        {
            var products = await _context.Products.Where(p => p.Price <= price).ToListAsync();
            return products;
        }
    }
}