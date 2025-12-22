using Fruitables_FinalProject_MVC.Models.SliderImage;

namespace Fruitables_FinalProject_MVC.Services.Interfaces
{
    public interface ISliderImageService
    {
        Task<IEnumerable<SliderImage>> GetAllAsync();
        Task<SliderImage> GetByIdAsync(int id);
        Task CreateAsync(SliderImageCreate model);
        Task DeleteAsync(int id);
        Task EditAsync(int id, SliderImageEdit model);
        Task<SliderImageEdit> GetEditAsync(int id);
    }
}