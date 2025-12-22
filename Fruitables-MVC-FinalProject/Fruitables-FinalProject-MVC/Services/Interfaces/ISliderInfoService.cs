using Fruitables_FinalProject_MVC.Models.SliderInfo;

namespace Fruitables_FinalProject_MVC.Services.Interfaces
{
    public interface ISliderInfoService
    {
        Task<IEnumerable<SliderInfo>> GetAllAsync();
        Task<SliderInfo> GetByIdAsync(int id);
        Task CreateAsync(SliderInfoCreate model);
        Task DeleteAsync(int id);
        Task EditAsync(int id, SliderInfoEdit model);
        Task<SliderInfoEdit> GetEditAsync(int id);
    }
}
