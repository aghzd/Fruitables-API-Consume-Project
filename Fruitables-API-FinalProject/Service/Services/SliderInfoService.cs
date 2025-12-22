using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Repository.Repositories.Interfaces;
using Service.DTOs.SliderInfo;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class SliderInfoService : ISliderInfoService
    {
        private readonly ISliderInfoRepository _repository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        public SliderInfoService(ISliderInfoRepository repository,
                                 IFileService fileService,
                                 IMapper mapper,
                                 IHttpContextAccessor accessor)
        {
            _repository = repository;
            _fileService = fileService;
            _mapper = mapper;
            _accessor = accessor;
        }
        public async Task CreateAsync(SliderInfoCreateDto model)
        {
            if (model.BackgroundImage == null) throw new ArgumentException("Image file is empty", nameof(model.BackgroundImage));

            var fileName = await _fileService.UploadFileAsync(model.BackgroundImage, "images");

            var entity = _mapper.Map<SliderInfo>(model);
            entity.BackgroundImage = fileName;

            await _repository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var sliderInfo = await _repository.GetByIdAsync(id);
            if (sliderInfo == null) throw new NotFoundException("Slider Info notfound");
            _fileService.DeleteFile(sliderInfo.BackgroundImage, "images");
            await _repository.DeleteAsync(sliderInfo);
        }

        public async Task EditAsync(int id, SliderInfoEditDto model)
        {
            var sliderInfo = await _repository.GetByIdAsync(id);
            if (sliderInfo == null) throw new NotFoundException("Slider Info notfound");

            if (model.BackgroundImage != null)
            {
                _fileService.DeleteFile(sliderInfo.BackgroundImage, "images");
                sliderInfo.BackgroundImage = await _fileService.UploadFileAsync(model.BackgroundImage, "images");
            }

            sliderInfo.Title = model.Title;
            sliderInfo.Description = model.Description;
            await _repository.EditAsync(sliderInfo);
        }

        public async Task<IEnumerable<SliderInfoDto>> GetAllAsync()
        {
            var request = _accessor.HttpContext.Request;
            var sliderInfos = await _repository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<SliderInfoDto>>(sliderInfos);
            foreach (var item in result)
            {
                item.BackgroundImage = $"{request.Scheme}://{request.Host}/images/{item.BackgroundImage}";
            }
            return result;
        }

        public async Task<SliderInfoDto> GetByIdAsync(int id)
        {
            var request = _accessor.HttpContext.Request;
            var sliderInfo = await _repository.GetByIdAsync(id);
            if (sliderInfo == null) throw new NotFoundException("Slider Info notfound");
            var result = _mapper.Map<SliderInfoDto>(sliderInfo);
            result.BackgroundImage = $"{request.Scheme}://{request.Host}/images/{result.BackgroundImage}";
            return result;
        }
    }
}