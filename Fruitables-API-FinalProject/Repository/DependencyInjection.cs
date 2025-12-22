using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Repositories.Interfaces;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ISliderImageRepository, SliderImageRepository>();
            services.AddScoped<ISliderInfoRepository, SliderInfoRepository>();
            services.AddScoped<IStoreFeatureRepository, StoreFeatureRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IStatsCardRepository, StatsCardRepository>();
            services.AddScoped<IProductOfferRepository, ProductOfferRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            return services;
        }
    }
}