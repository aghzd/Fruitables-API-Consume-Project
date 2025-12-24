using AutoMapper;
using Microsoft.AspNetCore.Http;
using Repository.Repositories.Interfaces;
using Service.DTOs.Basket;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        public BasketService(IBasketRepository repository,IMapper mapper,IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            _accessor = accessor;
        }

        public async Task<BasketDto> GetBasketAsync(string cookieKey)
        {
            var request = _accessor.HttpContext.Request;
            var basket = await _repository.GetBasketAsync(cookieKey);

            if (basket == null)
                return new BasketDto { CookieKey = cookieKey }; 

            var result =  _mapper.Map<BasketDto>(basket);
            foreach (var item in result.Items)
            {
                item.Image = $"{request.Scheme}://{request.Host}/images/{item.Image}";
            }
            return result;
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