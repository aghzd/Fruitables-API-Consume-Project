using Fruitables_FinalProject_MVC.Models.Contact;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using System.Net.Http;
using System.Text.Json;

namespace Fruitables_FinalProject_MVC.Services
{
    public class ContactAdminService : IContactAdminService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ContactAdminService(HttpClient httpClient, JsonSerializerOptions jsonOptions)
        {
            _httpClient = httpClient;
            _jsonOptions = jsonOptions;
        }
        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/admin/Contact/Delete/{id}");

            
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/admin/Contact/GetAll");

          

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Contact>>(content, _jsonOptions)!;
        }

        public async Task<Contact> GetByIdAsync(int id) 
        {
            var response = await _httpClient.GetAsync($"api/admin/Contact/GetById?id={id}");

           

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Contact>(content, _jsonOptions)!;
        }
    }
}