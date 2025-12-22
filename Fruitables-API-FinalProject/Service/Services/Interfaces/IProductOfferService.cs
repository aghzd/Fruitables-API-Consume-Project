using Service.DTOs.Product;
using Service.DTOs.Service;

namespace Service.Services.Interfaces
{
    public interface IProductOfferService
    {
        Task CreateAsync(ProductOfferCreateDto model);
        Task DeleteAsync(int id);
        Task EditAsync(int id,ProductOfferEditDto model);
        Task<IEnumerable<ProductOfferDto>> GetAllAsync();
        Task<ProductOfferDto> GetByIdAsync(int id);
    }
}