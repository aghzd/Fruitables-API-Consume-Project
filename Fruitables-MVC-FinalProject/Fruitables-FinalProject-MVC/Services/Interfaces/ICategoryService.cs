using Fruitables_FinalProject_MVC.Models.Category;

namespace Fruitables_FinalProject_MVC.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryCreate model);
        Task DeleteAsync(int id);
        Task EditAsync(int id,CategoryEdit model);
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<CategoryEdit> GetEditAsync(int id);
    }
}