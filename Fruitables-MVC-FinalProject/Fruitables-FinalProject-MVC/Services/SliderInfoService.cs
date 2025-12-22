using Fruitables_FinalProject_MVC.Models.SliderImage;
using Fruitables_FinalProject_MVC.Models.SliderInfo;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Fruitables_FinalProject_MVC.Services
{
    public class SliderInfoService : ISliderInfoService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public SliderInfoService(HttpClient httpClient, JsonSerializerOptions jsonOptions)
        {
            _httpClient = httpClient;
            _jsonOptions = jsonOptions;
        }

        public async Task CreateAsync(SliderInfoCreate model)
        {
            using var form = new MultipartFormDataContent();

            form.Add(new StringContent(model.Title ?? string.Empty), "Title");
            form.Add(new StringContent(model.Description ?? string.Empty), "Description");

            if (model.BackgroundImage != null && model.BackgroundImage.Length > 0)
            {
                var streamContent = new StreamContent(model.BackgroundImage.OpenReadStream());
                streamContent.Headers.ContentType =
                    new MediaTypeHeaderValue(model.BackgroundImage.ContentType);

                form.Add(streamContent, "BackgroundImage", model.BackgroundImage.FileName);
            }

            var response = await _httpClient.PostAsync(
                "api/admin/SliderInfo/Create", form);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/admin/SliderInfo/Delete/{id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task EditAsync(int id, SliderInfoEdit model)
        {
            using var form = new MultipartFormDataContent();

            form.Add(new StringContent(model.Title ?? string.Empty), "Title");
            form.Add(new StringContent(model.Description ?? string.Empty), "Description");

            if (model.BackgroundImage != null && model.BackgroundImage.Length > 0)
            {
                var streamContent = new StreamContent(model.BackgroundImage.OpenReadStream());
                streamContent.Headers.ContentType =
                    new MediaTypeHeaderValue(model.BackgroundImage.ContentType);

                form.Add(streamContent, "BackgroundImage", model.BackgroundImage.FileName);
            }

            var response = await _httpClient.PutAsync(
                $"api/admin/SliderInfo/Edit/{id}", form);

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<SliderInfo>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(
                "api/admin/SliderInfo/GetAll");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return Enumerable.Empty<SliderInfo>();

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<SliderInfo>>(json, _jsonOptions);
        }

        public async Task<SliderInfo> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(
                $"api/admin/SliderInfo/GetById?id={id}");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return null;

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SliderInfo>(json, _jsonOptions);
        }

        public async Task<SliderInfoEdit> GetEditAsync(int id)
        {
            var sliderInfo = await GetByIdAsync(id);
            if (sliderInfo == null) return null;

            return new SliderInfoEdit
            {
                Title = sliderInfo.Title,
                Description = sliderInfo.Description
            };
        }
    }
}