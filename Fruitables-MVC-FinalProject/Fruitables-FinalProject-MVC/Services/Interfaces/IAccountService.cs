using Fruitables_FinalProject_MVC.Models.Account;

namespace Fruitables_FinalProject_MVC.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(Register model);
        Task<LoginResponse> LoginAsync(Login model);
    }
}