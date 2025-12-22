using Fruitables_FinalProject_MVC.Models.ProductImage;

namespace Fruitables_FinalProject_MVC.Services.Interfaces
{
    public interface IProductImageService
    {
        Task CreateAsync(ProductImageCreate model);
        Task DeleteAsync(int id);
        Task EditAsync(int id,ProductImageEdit model);
        Task<ProductImageEdit> GetEditAsync(int id);
        Task<ProductImage> GetByIdAsync(int id);
        Task<IEnumerable<ProductImage>> GetAllAsync();
    }
}