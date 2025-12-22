using Fruitables_FinalProject_MVC.Models.Category;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using System.Net;
using System.Text.Json;

namespace Fruitables_FinalProject_MVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public CategoryService(HttpClient httpClient, JsonSerializerOptions jsonOptions)
        {
            _httpClient = httpClient;
            _jsonOptions = jsonOptions;
        }

        public async Task CreateAsync(CategoryCreate model)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/admin/Category/Create", model);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/admin/Category/Delete/{id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task EditAsync(int id, CategoryEdit model)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"api/admin/Category/Edit/{id}", model);

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(
                "api/admin/Category/GetAll");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return Enumerable.Empty<Category>();

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Category>>(json, _jsonOptions);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(
                $"api/admin/Category/GetById?id={id}");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return null;

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Category>(json, _jsonOptions);
        }

        public async Task<CategoryEdit> GetEditAsync(int id)
        {
            var category = await GetByIdAsync(id);
            if (category == null) return null;

            return new CategoryEdit
            {
                Name = category.Name,
                IsActive = category.IsActive
            };
        }

    }
}