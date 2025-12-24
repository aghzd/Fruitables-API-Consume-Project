using Service.DTOs.Contact;

namespace Service.Services.Interfaces
{
    public interface IContactService
    {
        Task CreateAsync(ContactCreateDto model);
        Task DeleteAsync(int id);
        Task<ContactDto> GetByIdAsync(int id);
        Task<IEnumerable<ContactDto>> GetAllAsync();
    }
}