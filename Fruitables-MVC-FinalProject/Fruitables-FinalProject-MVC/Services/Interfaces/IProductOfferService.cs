using Fruitables_FinalProject_MVC.Models.ProductOffer;

namespace Fruitables_FinalProject_MVC.Services.Interfaces
{
    public interface IProductOfferService
    {
        Task CreateAsync(ProductOfferCreate model);
        Task DeleteAsync(int id);   
        Task EditAsync(int id,ProductOfferEdit model);
        Task<ProductOfferEdit> GetEditAsync(int id);
        Task<ProductOffer> GetByIdAsync(int id);
        Task<IEnumerable<ProductOffer>> GetAllAsync();
    }
}