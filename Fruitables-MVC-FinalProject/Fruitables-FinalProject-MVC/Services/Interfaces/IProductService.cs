using Fruitables_FinalProject_MVC.Models.Product;

namespace Fruitables_FinalProject_MVC.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(ProductCreate model);
        Task EditAsync(int id,ProductEdit model);
        Task DeleteAsync(int id);
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<ProductEdit> GetEditAsync(int id);
    }
}