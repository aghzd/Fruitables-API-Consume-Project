using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Repository.Repositories.Interfaces;
using Service.DTOs.SliderImage;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class SliderImageService : ISliderImageService
    {
        private readonly ISliderImageRepository _repository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        public SliderImageService(ISliderImageRepository repository,
                                  IFileService fileService,
                                  IMapper mapper,
                                  IHttpContextAccessor accessor)
        {
            _repository = repository;
            _fileService = fileService;
            _mapper = mapper;
            _accessor = accessor;
        }
        public async Task CreateAsync(SliderImageCreateDto model)
        {
            if(model.Image == null) throw new ArgumentException("Image file is empty", nameof(model.Image));

            var fileName = await _fileService.UploadFileAsync(model.Image,"images");

            var entity = _mapper.Map<SliderImage>(model);
            entity.Image = fileName;

            await _repository.CreateAsync(entity);

        }

        public async Task DeleteAsync(int id)
        {
            var sliderImage = await _repository.GetByIdAsync(id);
            if (sliderImage == null) throw new NotFoundException("Slider Image notfound");
            _fileService.DeleteFile(sliderImage.Image,"images");
            await _repository.DeleteAsync(sliderImage);
        }


        public async Task EditAsync(int id, SliderImageEditDto model)
        {
            var sliderImage = await _repository.GetByIdAsync(id);
            if (sliderImage == null) throw new NotFoundException("Slider Image notfound");

            if (model.Image != null)
            {
                _fileService.DeleteFile(sliderImage.Image, "images");
                sliderImage.Image = await _fileService.UploadFileAsync(model.Image, "images");
            }
           
            sliderImage.CategoryName = model.CategoryName;
            sliderImage.IsActive = model.IsActive;
            await _repository.EditAsync(sliderImage);
        }

        public async Task<IEnumerable<SliderImageDto>> GetAllAsync()
        {
            var request = _accessor.HttpContext.Request;
            var sliderImages = await _repository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<SliderImageDto>>(sliderImages);
            foreach (var item in result)
            {
                item.Image = $"{request.Scheme}://{request.Host}/images/{item.Image}";
            }
            return result;
        }   

        public async Task<SliderImageDto> GetByIdAsync(int id)
        {
            var request = _accessor.HttpContext.Request;
            var sliderImage = await _repository.GetByIdAsync(id);
            if (sliderImage == null) throw new NotFoundException("Slider Image notfound");
            var result = _mapper.Map<SliderImageDto>(sliderImage);
            result.Image = $"{request.Scheme}://{request.Host}/images/{result.Image}";
            return result;
        }
    }
}