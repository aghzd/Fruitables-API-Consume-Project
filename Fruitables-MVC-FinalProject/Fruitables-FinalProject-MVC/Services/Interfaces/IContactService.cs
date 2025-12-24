using Fruitables_FinalProject_MVC.Models.Contact;

namespace Fruitables_FinalProject_MVC.Services.Interfaces
{
    public interface IContactService
    {
        Task CreateAsync(ContactCreate model);
        
    }
}