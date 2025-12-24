using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using Service.Services.Interfaces;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<ISliderImageService, SliderImageService>();
            services.AddScoped<ISliderInfoService, SliderInfoService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IStoreFeatureService, StoreFeatureService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IStatsCardService, StatsCardService>();
            services.AddScoped<IProductOfferService, ProductOfferService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IContactService, ContactService>();
            return services;
        }
    }
}