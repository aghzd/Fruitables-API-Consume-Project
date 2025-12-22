using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.StoreFeature;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class StoreFeatureService : IStoreFeatureService
    {
        private readonly IStoreFeatureRepository _repository;
        private readonly IMapper _mapper;
        public StoreFeatureService(IStoreFeatureRepository repository,IMapper mapper)
        {
            _repository = repository; 
            _mapper = mapper;
        }
        public async Task CreateAsync(StoreFeatureCreateDto model)
        {
            var storeFeature = _mapper.Map<StoreFeature>(model);
            await _repository.CreateAsync(storeFeature);
        }

        public async Task DeleteAsync(int id)
        {
            var storeFeature = await _repository.GetByIdAsync(id);
            if (storeFeature == null) throw new NotFoundException("Store Feature notfound");
            await _repository.DeleteAsync(storeFeature);
        }

        public async Task EditAsync(int id, StoreFeatureEditDto model)
        {
            var storeFeature = await _repository.GetByIdAsync(id);
            if (storeFeature == null) throw new NotFoundException("Store Feature notfound");
            storeFeature.Feature = model.Feature;
            storeFeature.Description = model.Description;
            storeFeature.IconName = model.IconName;
            await _repository.EditAsync(storeFeature);
        }

        public async Task<IEnumerable<StoreFeatureDto>> GetAllAsync()
        {
            var storeFeatures = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<StoreFeatureDto>>(storeFeatures);
        }

        public async Task<StoreFeatureDto> GetByIdAsync(int id)
        {
            var storeFeature = await _repository.GetByIdAsync(id);
            if (storeFeature == null) throw new NotFoundException("Store Feature notfound");
            return _mapper.Map<StoreFeatureDto>(storeFeature);
        }
    }
}