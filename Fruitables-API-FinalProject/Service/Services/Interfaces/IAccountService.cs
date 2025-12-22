using Service.DTOs.Account;
using Service.Helpers.Responses;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResponse> RegisterAsync(RegisterDto model);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserById(string id);
        Task CreateRolesAsync();
        Task<IEnumerable<RoleDto>> GetRolesAsync();
        Task<RoleDto> GetRoleByIdAsync(string id);
        Task DeleteUserAsync(string id);
        Task<ServiceResponse> AddRoleToUserAsync(UserRoleDto model);
        Task<ServiceResponse> RemoveRoleFromUser(UserRoleDto model);
        Task<LoginResponse> LoginAsync(LoginDto model);
    }
}