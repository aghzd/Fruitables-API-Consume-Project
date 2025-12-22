using Service.DTOs.ProductImage;

namespace Service.Services.Interfaces
{
    public interface IProductImageService
    {
        Task CreateAsync(ProductImageCreateDto model);
        Task DeleteAsync(int id);
        Task EditAsync(int id, ProductImageEditDto model);
        Task<IEnumerable<ProductImageDto>> GetAllAsync();
        Task<ProductImageDto> GetByIdAsync(int id);
    }
}