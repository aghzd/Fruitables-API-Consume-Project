using Fruitables_FinalProject_MVC.Models.StoreFeature;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using System.Net;
using System.Text.Json;

namespace Fruitables_FinalProject_MVC.Services
{
    public class StoreFeatureService : IStoreFeatureService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public StoreFeatureService(HttpClient httpClient, JsonSerializerOptions jsonOptions)
        {
            _httpClient = httpClient;
            _jsonOptions = jsonOptions;
        }

        public async Task CreateAsync(StoreFeatureCreate model)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/admin/StoreFeature/Create", model);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/admin/StoreFeature/Delete/{id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task EditAsync(int id, StoreFeatureEdit model)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"api/admin/StoreFeature/Edit/{id}", model);

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<StoreFeature>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/admin/StoreFeature/GetAll");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return Enumerable.Empty<StoreFeature>();

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<StoreFeature>>(json, _jsonOptions);
        }

        public async Task<StoreFeature> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/admin/StoreFeature/GetById?id={id}");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return null;

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StoreFeature>(json, _jsonOptions);
        }

        public async Task<StoreFeatureEdit> GetEditAsync(int id)
        {
            var storeFeature = await GetByIdAsync(id);
            if (storeFeature == null) return null;

            return new StoreFeatureEdit
            {
                IconName = storeFeature.IconName,
                Description = storeFeature.Description,
                Feature = storeFeature.Feature
            };
        }
    }
}