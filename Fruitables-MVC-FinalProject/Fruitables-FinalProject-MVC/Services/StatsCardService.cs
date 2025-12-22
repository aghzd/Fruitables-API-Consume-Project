using Fruitables_FinalProject_MVC.Models.StatsCard;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using System.Net;
using System.Text.Json;

namespace Fruitables_FinalProject_MVC.Services
{
    public class StatsCardService : IStatsCardService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StatsCardService(HttpClient httpClient, 
                                JsonSerializerOptions jsonOptions,
                                IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _jsonOptions = jsonOptions;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task CreateAsync(StatsCardCreate model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/admin/StatsCard/Create", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task EditAsync(int id, StatsCardEdit model)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/admin/StatsCard/Edit/{id}", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/admin/StatsCard/Delete/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<StatsCard>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/admin/StatsCard/GetAll");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return Enumerable.Empty<StatsCard>();

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<StatsCard>>(json, _jsonOptions);
        }

        public async Task<StatsCard> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/admin/StatsCard/GetById?id={id}");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return null; 

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StatsCard>(json, _jsonOptions);
        }

        public async Task<StatsCardEdit> GetEditAsync(int id)
        {
            var statsCard = await GetByIdAsync(id); 
            if (statsCard == null) return null;

            var result = new StatsCardEdit()
            {
                Name = statsCard.Name,
                IconName = statsCard.IconName,
                IsPercent = statsCard.IsPercent,
                Value = statsCard.Value,
            };

            return result;
        }
    }
}   