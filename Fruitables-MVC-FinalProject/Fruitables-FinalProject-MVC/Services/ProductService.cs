using Fruitables_FinalProject_MVC.Models.Product;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using System.Net;
using System.Text.Json;

namespace Fruitables_FinalProject_MVC.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ProductService(HttpClient httpClient, JsonSerializerOptions jsonOptions)
        {
            _httpClient = httpClient;
            _jsonOptions = jsonOptions;
        }

        public async Task CreateAsync(ProductCreate model)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/admin/Product/Create", model);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/admin/Product/Delete/{id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task EditAsync(int id, ProductEdit model)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"api/admin/Product/Edit/{id}", model);

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(
                "api/admin/Product/GetAll");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return Enumerable.Empty<Product>();

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Product>>(json, _jsonOptions);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(
                $"api/admin/Product/GetById?id={id}");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return null;

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Product>(json, _jsonOptions);
        }

        public async Task<ProductEdit> GetEditAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product == null) return null;

            return new ProductEdit
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Unit = product.Unit,
                CategoryId = product.CategoryId
            };
        }
    }
}