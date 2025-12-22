using Service.DTOs.StoreFeature;

namespace Service.Services.Interfaces
{
    public interface IStoreFeatureService
    {
        Task CreateAsync(StoreFeatureCreateDto model);
        Task<IEnumerable<StoreFeatureDto>> GetAllAsync();
        Task<StoreFeatureDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task EditAsync(int id , StoreFeatureEditDto model);
    }
}
