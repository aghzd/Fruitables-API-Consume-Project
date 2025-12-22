using Service.DTOs.SliderInfo;

namespace Service.Services.Interfaces
{
    public interface ISliderInfoService
    {
        Task CreateAsync(SliderInfoCreateDto model);
        Task DeleteAsync(int id);
        Task EditAsync(int id, SliderInfoEditDto model);
        Task<SliderInfoDto> GetByIdAsync(int id);
        Task<IEnumerable<SliderInfoDto>> GetAllAsync();
    }
}