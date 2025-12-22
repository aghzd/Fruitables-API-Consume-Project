using Service.DTOs.Product;

namespace Service.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(ProductCreateDto model);
        Task DeleteAsync(int id);
        Task EditAsync(int id,ProductEditDto model);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> SortByPriceAsync(int price);
        Task<IEnumerable<ProductDto>> SearchAsync(string search);
        Task<IEnumerable<ProductDto>> GetPaginatedDatas(int page);
    }
}