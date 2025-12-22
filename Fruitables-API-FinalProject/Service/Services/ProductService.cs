using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Repository.Repositories.Interfaces;
using Service.DTOs.Product;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        public ProductService(IProductRepository repository,
                              IMapper mapper,
                              IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            _accessor = accessor;
        }
        public async Task CreateAsync(ProductCreateDto model)
        {
            var product = _mapper.Map<Product>(model);
            await _repository.CreateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) throw new NotFoundException("Product notfound");
            await _repository.DeleteAsync(product);
        }

        public async Task EditAsync(int id, ProductEditDto model)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) throw new NotFoundException("Product notfound");
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Unit = model.Unit;
            product.CategoryId= model.CategoryId;
            await _repository.EditAsync(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var request = _accessor.HttpContext.Request;
            var products = await _repository.GetAllWithImages();
            var result = _mapper.Map<IEnumerable<ProductDto>>(products);
            foreach (var product in result)
            {
                foreach (var img in product.ProductImages)
                {
                    img.Name = $"{request.Scheme}://{request.Host}/images/{img.Name}";
                }
            }
            return result;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var request = _accessor.HttpContext.Request;
            var product = await _repository.GetByIdWithImages(id);
            if (product == null) throw new NotFoundException("Product notfound");
            var result = _mapper.Map<ProductDto>(product);
            foreach (var img in result.ProductImages) 
            {
                img.Name = $"{request.Scheme}://{request.Host}/images/{img.Name}";
            }
            return result;
        }

        public async Task<IEnumerable<ProductDto>> GetPaginatedDatas(int page)
        {
            var products = await _repository.GetPaginatedDatas(page);
            if (products == null) throw new NotFoundException("Products notfound");
            var result = _mapper.Map<IEnumerable<ProductDto>>(products);
            return result;
        }

        public async Task<IEnumerable<ProductDto>> SearchAsync(string search)
        {
            var products = await _repository.SearchAsync(search);
            if (products == null) throw new NotFoundException("Products notfound");
            var result = _mapper.Map<IEnumerable<ProductDto>>(products);
            return result;
        }

        public async Task<IEnumerable<ProductDto>> SortByPriceAsync(int price)
        {
            var products = await _repository.SortByPriceAsync(price);
            if (products == null) throw new NotFoundException("Products notfound");
            var result = _mapper.Map<IEnumerable<ProductDto>>(products);
            return result;
        }
    }
}