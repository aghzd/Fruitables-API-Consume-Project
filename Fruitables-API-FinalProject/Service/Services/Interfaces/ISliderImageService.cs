using Service.DTOs.SliderImage;

namespace Service.Services.Interfaces
{
    public interface ISliderImageService
    {
        Task CreateAsync(SliderImageCreateDto model);
        Task DeleteAsync(int id);
        Task EditAsync(int id , SliderImageEditDto model);
        Task<SliderImageDto> GetByIdAsync(int id);
        Task<IEnumerable<SliderImageDto>> GetAllAsync();
    }
}
