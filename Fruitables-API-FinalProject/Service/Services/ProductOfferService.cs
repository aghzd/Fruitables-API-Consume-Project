using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Repository.Repositories.Interfaces;
using Service.DTOs.Service;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class ProductOfferService : IProductOfferService
    {
        private readonly IProductOfferRepository _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _accessor;
        public ProductOfferService(IProductOfferRepository repository,
                                   IMapper mapper,
                                   IFileService fileService,
                                   IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = fileService;
            _accessor = accessor;
        }
        public async Task CreateAsync(ProductOfferCreateDto model)
        {
            if (model.Image == null) throw new ArgumentException("Image file is empty", nameof(model.Image));

            var fileName = await _fileService.UploadFileAsync(model.Image, "images");

            var product = _mapper.Map<ProductOffer>(model);
            product.Image = fileName;
            await _repository.CreateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var productOffer = await _repository.GetByIdAsync(id);
            if (productOffer == null) throw new NotFoundException("Product Offer notfound");
            _fileService.DeleteFile(productOffer.Image, "images");
            await _repository.DeleteAsync(productOffer);
        }

        public async Task EditAsync(int id, ProductOfferEditDto model)
        {
            var productOffer = await _repository.GetByIdAsync(id);
            if (productOffer == null) throw new NotFoundException("Product Offer notfound");
            if (model.Image != null)
            {
                _fileService.DeleteFile(productOffer.Image, "images");
                productOffer.Image = await _fileService.UploadFileAsync(model.Image, "images");
            }

            productOffer.Description = model.Description;
            productOffer.Name = model.Name;
            productOffer.NameColor = model.NameColor;
            productOffer.BackgroundColor = model.BackgroundColor;
            productOffer.TextColor = model.TextColor;
            await _repository.EditAsync(productOffer);
        }

        public async Task<IEnumerable<ProductOfferDto>> GetAllAsync()
        {
            var request = _accessor.HttpContext.Request;
            var products = await _repository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<ProductOfferDto>>(products);
            foreach (var item in result)
            {
                item.Image = $"{request.Scheme}://{request.Host}/images/{item.Image}";
            }
            return result;
        }

        public async Task<ProductOfferDto> GetByIdAsync(int id)
        {
            var request = _accessor.HttpContext.Request;
            var productOffer = await _repository.GetByIdAsync(id);
            if (productOffer == null) throw new NotFoundException("Product Offer notfound");
            var result = _mapper.Map<ProductOfferDto>(productOffer);
            result.Image = $"{request.Scheme}://{request.Host}/images/{result.Image}";
            return result;
        }
    }
}