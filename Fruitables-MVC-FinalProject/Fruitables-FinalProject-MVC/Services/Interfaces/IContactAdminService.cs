using Fruitables_FinalProject_MVC.Models.Contact;

namespace Fruitables_FinalProject_MVC.Services.Interfaces
{
    public interface IContactAdminService
    {
        Task DeleteAsync(int id);
        Task<Contact> GetByIdAsync(int id);
        Task<IEnumerable<Contact>> GetAllAsync();
    }
}