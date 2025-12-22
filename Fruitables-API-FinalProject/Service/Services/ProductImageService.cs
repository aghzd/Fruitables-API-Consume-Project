using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Repository.Repositories.Interfaces;
using Service.DTOs.ProductImage;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _repository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        public ProductImageService(IProductImageRepository repository,
                                   IMapper mapper,
                                   IFileService fileService,
                                   IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = fileService;
            _accessor = accessor;
        }
        public async Task CreateAsync(ProductImageCreateDto model)
        {
            if (model.Name == null) throw new ArgumentException("Image file is empty", nameof(model.Name));

            var fileName = await _fileService.UploadFileAsync(model.Name, "images");

            var productImage = _mapper.Map<ProductImage>(model);

            productImage.Name = fileName;
            
            await _repository.CreateAsync(productImage);
        }

        public async Task DeleteAsync(int id)
        {
            var productImage = await _repository.GetByIdAsync(id);
            if (productImage == null) throw new NotFoundException("Product Image notfound");
            _fileService.DeleteFile(productImage.Name, "images");
            await _repository.DeleteAsync(productImage);
        }

        public async Task EditAsync(int id, ProductImageEditDto model)
        {
            var productImage = await _repository.GetByIdAsync(id);
            if (productImage == null) throw new NotFoundException("Product Image notfound");

            if (model.Name != null)
            {
                _fileService.DeleteFile(productImage.Name, "images");
                productImage.Name = await _fileService.UploadFileAsync(model.Name, "images");
            }

            productImage.ProductId = model.ProductId;
            productImage.IsMain = model.IsMain;
            await _repository.EditAsync(productImage);
        }

        public async Task<IEnumerable<ProductImageDto>> GetAllAsync()
        {
            var request = _accessor.HttpContext.Request;
            var productImages = await _repository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<ProductImageDto>>(productImages);
            foreach (var item in result)
            {
                item.Name = $"{request.Scheme}://{request.Host}/images/{item.Name}";
            }
            return result;
        }

        public async Task<ProductImageDto> GetByIdAsync(int id)
        {
            var request = _accessor.HttpContext.Request;
            var productImage = await _repository.GetByIdAsync(id);
            if (productImage == null) throw new NotFoundException("Product Image notfound");
            var result = _mapper.Map<ProductImageDto>(productImage);
            result.Name = $"{request.Scheme}://{request.Host}/images/{result.Name}";
            return result;
        }
    }
}