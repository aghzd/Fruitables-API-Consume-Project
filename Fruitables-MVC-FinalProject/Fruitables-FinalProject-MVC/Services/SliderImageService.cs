using Fruitables_FinalProject_MVC.Models.SliderImage;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Fruitables_FinalProject_MVC.Services
{
    public class SliderImageService : ISliderImageService
    {
        //private readonly HttpClient _httpClient;
        //private readonly JsonSerializerOptions _jsonOptions;
        //public SliderImageService(HttpClient httpClient, JsonSerializerOptions jsonOptions)
        //{
        //    _httpClient = httpClient;
        //    _jsonOptions = jsonOptions;
        //}
        //public async Task CreateAsync(SliderImageCreate model)
        //{
        //    using var form = new MultipartFormDataContent();

        //    form.Add(new StringContent(model.CategoryName ?? ""), "CategoryName");
        //    form.Add(new StringContent(model.IsActive.ToString().ToLower()), "IsActive");

        //    if (model.Image != null && model.Image.Length > 0)
        //    {
        //        var streamContent = new StreamContent(model.Image.OpenReadStream());
        //        streamContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);
        //        form.Add(streamContent, "Image", model.Image.FileName);
        //    }

        //    await _httpClient.PostAsync(
        //        "https://localhost:7178/api/admin/SliderImage/Create",
        //        form
        //    );
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    await _httpClient.DeleteAsync($"https://localhost:7178/api/admin/SliderImage/Delete/{id}");
        //}

        //public async Task<IEnumerable<SliderImage>> GetAllAsync()
        //{
        //    var response = await _httpClient.GetAsync("https://localhost:7178/api/admin/SliderImage/GetAll");
        //    var json = await response.Content.ReadAsStringAsync();
        //    return JsonSerializer.Deserialize<IEnumerable<SliderImage>>(json, _jsonOptions);
        //}

        //public async Task<SliderImage> GetByIdAsync(int id)
        //{
        //    var response = await _httpClient.GetAsync($"https://localhost:7178/api/admin/SliderImage/GetById?id={id}");
        //    var json = await response.Content.ReadAsStringAsync();
        //    return JsonSerializer.Deserialize<SliderImage>(json, _jsonOptions);
        //}

        //public async Task EditAsync(int id, SliderImageEdit model)
        //{
        //    using var form = new MultipartFormDataContent();

        //    form.Add(new StringContent(model.CategoryName ?? ""), "CategoryName");

        //    form.Add(new StringContent(model.IsActive.ToString().ToLower()), "IsActive");

        //    if (model.Image != null && model.Image.Length > 0)
        //    {
        //        var streamContent = new StreamContent(model.Image.OpenReadStream());
        //        streamContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);
        //        form.Add(streamContent, "Image", model.Image.FileName);
        //    }

        //    await _httpClient.PutAsync(
        //        $"https://localhost:7178/api/admin/SliderImage/Edit/{id}",
        //        form
        //    );
        //}

        //public async Task<SliderImageEdit> GetEditAsync(int id)
        //{
        //    var response = await _httpClient.GetAsync($"https://localhost:7178/api/admin/SliderImage/GetById?id={id}");

        //    var json = await response.Content.ReadAsStringAsync();

        //    using var doc = JsonDocument.Parse(json);
        //    var root = doc.RootElement;

        //    var slider = new SliderImageEdit
        //    {
        //        CategoryName = root.GetProperty("categoryName").GetString(),
        //        IsActive = root.GetProperty("isActive").GetBoolean()
        //    };
        //    return slider;
        //}

        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public SliderImageService(HttpClient httpClient, JsonSerializerOptions jsonOptions)
        {
            _httpClient = httpClient;
            _jsonOptions = jsonOptions;
        }

        public async Task CreateAsync(SliderImageCreate model)
        {
            using var form = new MultipartFormDataContent();

            form.Add(new StringContent(model.CategoryName ?? string.Empty), "CategoryName");
            form.Add(new StringContent(model.IsActive.ToString().ToLower()), "IsActive");

            if (model.Image != null && model.Image.Length > 0)
            {
                var streamContent = new StreamContent(model.Image.OpenReadStream());
                streamContent.Headers.ContentType =
                    new MediaTypeHeaderValue(model.Image.ContentType);

                form.Add(streamContent, "Image", model.Image.FileName);
            }

            var response = await _httpClient.PostAsync(
                "api/admin/SliderImage/Create", form);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/admin/SliderImage/Delete/{id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<SliderImage>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(
                "api/admin/SliderImage/GetAll");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return Enumerable.Empty<SliderImage>();

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<SliderImage>>(json, _jsonOptions);
        }

        public async Task<SliderImage> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(
                $"api/admin/SliderImage/GetById?id={id}");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return null;

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SliderImage>(json, _jsonOptions);
        }

        public async Task EditAsync(int id, SliderImageEdit model)
        {
            using var form = new MultipartFormDataContent();

            form.Add(new StringContent(model.CategoryName ?? string.Empty), "CategoryName");
            form.Add(new StringContent(model.IsActive.ToString().ToLower()), "IsActive");

            if (model.Image != null && model.Image.Length > 0)
            {
                var streamContent = new StreamContent(model.Image.OpenReadStream());
                streamContent.Headers.ContentType =
                    new MediaTypeHeaderValue(model.Image.ContentType);

                form.Add(streamContent, "Image", model.Image.FileName);
            }

            var response = await _httpClient.PutAsync(
                $"api/admin/SliderImage/Edit/{id}", form);

            response.EnsureSuccessStatusCode();
        }

        public async Task<SliderImageEdit> GetEditAsync(int id)
        {
            var slider = await GetByIdAsync(id);
            if (slider == null) return null;

            return new SliderImageEdit
            {
                CategoryName = slider.CategoryName,
                IsActive = slider.IsActive
            };
        }
    }
}