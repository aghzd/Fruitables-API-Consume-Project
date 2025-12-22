using Fruitables_FinalProject_MVC.Models.ProductImage;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Fruitables_FinalProject_MVC.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ProductImageService(HttpClient httpClient, JsonSerializerOptions jsonOptions)
        {
            _httpClient = httpClient;
            _jsonOptions = jsonOptions;
        }

        public async Task CreateAsync(ProductImageCreate model)
        {
            using var form = new MultipartFormDataContent();

            form.Add(new StringContent(model.IsMain.ToString().ToLower()), "IsMain");
            form.Add(new StringContent(model.ProductId.ToString()), "ProductId");

            if (model.Name != null && model.Name.Length > 0)
            {
                var streamContent = new StreamContent(model.Name.OpenReadStream());
                streamContent.Headers.ContentType =
                    new MediaTypeHeaderValue(model.Name.ContentType);

                form.Add(streamContent, "Name", model.Name.FileName);
            }

            var response = await _httpClient.PostAsync(
                "api/admin/ProductImage/Create", form);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/admin/ProductImage/Delete/{id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task EditAsync(int id, ProductImageEdit model)
        {
            using var form = new MultipartFormDataContent();

            form.Add(new StringContent(model.IsMain.ToString().ToLower()), "IsMain");
            form.Add(new StringContent(model.ProductId.ToString()), "ProductId");

            if (model.Name != null && model.Name.Length > 0)
            {
                var streamContent = new StreamContent(model.Name.OpenReadStream());
                streamContent.Headers.ContentType =
                    new MediaTypeHeaderValue(model.Name.ContentType);

                form.Add(streamContent, "Name", model.Name.FileName);
            }

            var response = await _httpClient.PutAsync(
                $"api/admin/ProductImage/Edit/{id}", form);

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<ProductImage>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(
                "api/admin/ProductImage/GetAll");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return Enumerable.Empty<ProductImage>();

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<ProductImage>>(json, _jsonOptions);
        }

        public async Task<ProductImage> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(
                $"api/admin/ProductImage/GetById?id={id}");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return null;

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProductImage>(json, _jsonOptions);
        }

        public async Task<ProductImageEdit> GetEditAsync(int id)
        {
            var productImage = await GetByIdAsync(id);
            if (productImage == null) return null;

            return new ProductImageEdit
            {
                IsMain = productImage.IsMain,
                ProductId = productImage.ProductId
            };
        }
    }
}