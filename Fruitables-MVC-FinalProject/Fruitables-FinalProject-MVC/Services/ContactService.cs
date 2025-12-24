using Fruitables_FinalProject_MVC.Models.Contact;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using System.Text.Json;

namespace Fruitables_FinalProject_MVC.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ContactService(HttpClient httpClient, JsonSerializerOptions jsonOptions)
        {
            _httpClient = httpClient;
            _jsonOptions = jsonOptions;
        }
        public async Task CreateAsync(ContactCreate model)
        {
            var response = await _httpClient.PostAsJsonAsync("Contact/Create", model);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cant create contact");
            }
        }

    }
}