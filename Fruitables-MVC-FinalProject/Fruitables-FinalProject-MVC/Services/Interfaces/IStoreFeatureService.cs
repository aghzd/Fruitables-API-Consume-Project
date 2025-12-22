using Fruitables_FinalProject_MVC.Models.StoreFeature;

namespace Fruitables_FinalProject_MVC.Services.Interfaces
{
    public interface IStoreFeatureService
    {
        Task CreateAsync(StoreFeatureCreate model);
        Task DeleteAsync(int id);
        Task EditAsync(int id,StoreFeatureEdit model);
        Task<StoreFeature> GetByIdAsync(int id);
        Task<IEnumerable<StoreFeature>> GetAllAsync();
        Task<StoreFeatureEdit> GetEditAsync(int id);
    }
}