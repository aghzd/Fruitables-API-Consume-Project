using Fruitables_FinalProject_MVC.Models.Account;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace Fruitables_FinalProject_MVC.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AccountService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(_configuration["ApiBaseUrl"]);
        }

        public async Task<LoginResponse> LoginAsync(Login model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Account/Login", content);

            if (!response.IsSuccessStatusCode)
            {
                return new LoginResponse
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Username or password is incorrect" }
                };
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LoginResponse>(responseBody);
        }
        

        public async Task<bool> RegisterAsync(Register model)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }
    }
}