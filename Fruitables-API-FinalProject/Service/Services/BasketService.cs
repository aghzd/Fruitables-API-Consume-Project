using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Basket;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _repository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //public async Task<Basket> GetBasketAsync(string cookieKey)
        //{
        //    return await _repository.GetBasketAsync(cookieKey);
        //}

        public async Task<BasketDto> GetBasketAsync(string cookieKey)
        {
            var basket = await _repository.GetBasketAsync(cookieKey);

            if (basket == null)
                return new BasketDto { CookieKey = cookieKey }; // boş basket qaytar

            return _mapper.Map<BasketDto>(basket);
        }

        public async Task AddItemAsync(string cookieKey, AddBasketItemDto dto)
        {
            await _repository.AddItemAsync(cookieKey, dto.ProductId, dto.Quantity);
        }
            

        public async Task DeleteItemAsync(string cookieKey, int productId)
        {
            await _repository.DeleteItemAsync(cookieKey, productId);
        }
    }
}