using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.DTOs.Account;
using Service.Helpers;
using Service.Helpers.Enums;
using Service.Helpers.Exceptions;
using Service.Helpers.Responses;
using Service.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;
        public AccountService(UserManager<AppUser> userManager,
                              IMapper mapper,
                              RoleManager<IdentityRole> roleManager,
                              IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<ServiceResponse> AddRoleToUserAsync(UserRoleDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) throw new NotFoundException("user not found");

            var role = await _roleManager.FindByIdAsync(model.RoleId);
            if (role == null) throw new NotFoundException("role not found");

            if(await _userManager.IsInRoleAsync(user, role.Name))
            {
                return new ServiceResponse { IsSuccess = false, Messages = ["This role already exists in user"] };
            }

            await _userManager.AddToRoleAsync(user, role.Name);
            return new ServiceResponse { IsSuccess = true, Messages = ["Role added succesfully"] };
        }

        public async Task CreateRolesAsync()
        {
            foreach(var role in Enum.GetValues(typeof(Roles)))
            {
                if(!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) throw new NotFoundException("user notfound");
            await _userManager.DeleteAsync(user);
        }

        public async Task<RoleDto> GetRoleByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if(role == null) throw new NotFoundException("role not found");
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<IEnumerable<RoleDto>> GetRolesAsync()
        {
            var roles  = await _roleManager.Roles.ToListAsync();
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task<UserDto> GetUserById(string id)
        {
            var user  = await _userManager.FindByIdAsync(id);
            if (user == null) throw new NotFoundException("user notfound");
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var mappedUsers = _mapper.Map<IEnumerable<UserDto>>(users);
            foreach (var user in mappedUsers)
            {
                var userEntity = await _userManager.FindByIdAsync(user.Id);
                var roles = await _userManager.GetRolesAsync(userEntity);
                user.Roles = roles.ToArray();
            }
            return mappedUsers;
        }

        public async Task<LoginResponse> LoginAsync(LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.EmailOrUserName)
               ?? await _userManager.FindByEmailAsync(model.EmailOrUserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                throw new UnauthorizedAccessException("Username, email or password is incorrect");

            var roles = await _userManager.GetRolesAsync(user);

            string token = GenerateJwtToken(user.UserName, roles.ToList());

            return new LoginResponse
            {
                IsSuccess = true,
                Errors = null,
                Token = token
            };
        }

        private string GenerateJwtToken(string userName, List<string> roles)
        {

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userName),
            };

            roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpireDays));

            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }




        public async Task<RegisterResponse> RegisterAsync(RegisterDto model)
        {
            AppUser user = new()
            {
                FullName = model.FullName,
                Email = model.Email,
                UserName = model.UserName,
            };
            var result = await _userManager.CreateAsync(user,model.Password);
            if (!result.Succeeded)
            {
                return new RegisterResponse
                {
                    IsSuccess = false,
                    Errors = result.Errors.Select(m => m.Description).ToList()
                };
            }


            await _userManager.AddToRoleAsync(user, Roles.Member.ToString());



            return new RegisterResponse
            {
                IsSuccess = true,
                Errors = null
            };
        }


        public async Task<ServiceResponse> RemoveRoleFromUser(UserRoleDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) throw new NotFoundException("user notfound");

            var role = await _roleManager.FindByIdAsync(model.RoleId);
            if (role == null) throw new NotFoundException("role notfound");

            if (!await _userManager.IsInRoleAsync(user, role.Name))
            {
                return new ServiceResponse { IsSuccess = false, Messages = ["This role doesnt exists in user"] };
            }

            await _userManager.RemoveFromRoleAsync(user, role.Name);
            return new ServiceResponse { IsSuccess = true, Messages = ["Role removed succesfully"] };
        }
    }
}