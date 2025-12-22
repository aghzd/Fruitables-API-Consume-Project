using Fruitables_FinalProject_MVC.Models.StatsCard;

namespace Fruitables_FinalProject_MVC.Services.Interfaces
{
    public interface IStatsCardService
    {
        Task CreateAsync(StatsCardCreate model);
        Task DeleteAsync(int id);
        Task EditAsync(int id,StatsCardEdit model);
        Task<StatsCard> GetByIdAsync(int id);
        Task<IEnumerable<StatsCard>> GetAllAsync();
        Task<StatsCardEdit> GetEditAsync(int id);
    }
}