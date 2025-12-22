using Service.DTOs.StatsCard;

namespace Service.Services.Interfaces
{
    public interface IStatsCardService
    {
        Task CreateAsync(StatsCardCreateDto model);
        Task EditAsync(int id,StatsCardEditDto model);
        Task DeleteAsync(int id);
        Task<IEnumerable<StatsCardDto>> GetAllAsync();
        Task<StatsCardDto> GetById(int id);
    }
}