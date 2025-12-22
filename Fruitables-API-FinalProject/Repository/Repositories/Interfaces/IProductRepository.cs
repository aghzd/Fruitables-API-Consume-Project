using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> SearchAsync(string search);
        Task<IEnumerable<Product>> SortByPriceAsync(int price);
        Task<IEnumerable<Product>> GetAllWithImages();
        Task<Product> GetByIdWithImages(int id);
        Task<IEnumerable<Product>> GetPaginatedDatas(int page, int take = 3);
    }
}