using Service.DTOs.Category;

namespace Service.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryCreateDto model);
        Task DeleteAsync(int id);
        Task EditAsync(int id,CategoryEditDto model);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetById(int id);
    }
}