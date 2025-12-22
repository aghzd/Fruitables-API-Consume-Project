using Fruitables_FinalProject_MVC.Models.ProductOffer;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Fruitables_FinalProject_MVC.Services
{
    public class ProductOfferService : IProductOfferService
    {

        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ProductOfferService(HttpClient httpClient, JsonSerializerOptions jsonOptions)
        {
            _httpClient = httpClient;
            _jsonOptions = jsonOptions;
        }

        public async Task CreateAsync(ProductOfferCreate model)
        {
            using var form = new MultipartFormDataContent();

            form.Add(new StringContent(model.Name ?? string.Empty), "Name");
            form.Add(new StringContent(model.Description ?? string.Empty), "Description");
            form.Add(new StringContent(model.NameColor ?? string.Empty), "NameColor");
            form.Add(new StringContent(model.BackgroundColor ?? string.Empty), "BackgroundColor");
            form.Add(new StringContent(model.TextColor ?? string.Empty), "TextColor");

            if (model.Image != null && model.Image.Length > 0)
            {
                var streamContent = new StreamContent(model.Image.OpenReadStream());
                streamContent.Headers.ContentType =
                    new MediaTypeHeaderValue(model.Image.ContentType);

                form.Add(streamContent, "Image", model.Image.FileName);
            }

            var response = await _httpClient.PostAsync(
                "api/admin/ProductOffer/Create", form);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/admin/ProductOffer/Delete/{id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task EditAsync(int id, ProductOfferEdit model)
        {
            using var form = new MultipartFormDataContent();

            form.Add(new StringContent(model.Name ?? string.Empty), "Name");
            form.Add(new StringContent(model.Description ?? string.Empty), "Description");
            form.Add(new StringContent(model.NameColor ?? string.Empty), "NameColor");
            form.Add(new StringContent(model.BackgroundColor ?? string.Empty), "BackgroundColor");
            form.Add(new StringContent(model.TextColor ?? string.Empty), "TextColor");

            if (model.Image != null && model.Image.Length > 0)
            {
                var streamContent = new StreamContent(model.Image.OpenReadStream());
                streamContent.Headers.ContentType =
                    new MediaTypeHeaderValue(model.Image.ContentType);

                form.Add(streamContent, "Image", model.Image.FileName);
            }

            var response = await _httpClient.PutAsync(
                $"api/admin/ProductOffer/Edit/{id}", form);

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<ProductOffer>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(
                "api/admin/ProductOffer/GetAll");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return Enumerable.Empty<ProductOffer>();

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<ProductOffer>>(json, _jsonOptions);
        }

        public async Task<ProductOffer> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(
                $"api/admin/ProductOffer/GetById?id={id}");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return null;

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProductOffer>(json, _jsonOptions);
        }

        public async Task<ProductOfferEdit> GetEditAsync(int id)
        {
            var productOffer = await GetByIdAsync(id);
            if (productOffer == null) return null;

            return new ProductOfferEdit
            {
                Name = productOffer.Name,
                Description = productOffer.Description,
                NameColor = productOffer.NameColor,
                BackgroundColor = productOffer.BackgroundColor,
                TextColor = productOffer.TextColor
            };
        }
    }
}   