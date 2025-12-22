using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.StatsCard;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class StatsCardService : IStatsCardService
    {
        private readonly IStatsCardRepository _repository;
        private readonly IMapper _mapper;
        public StatsCardService(IStatsCardRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(StatsCardCreateDto model)
        {
            var statscard = _mapper.Map<StatsCard>(model);
            await _repository.CreateAsync(statscard);
        }

        public async Task DeleteAsync(int id)
        {
            var statsCard = await _repository.GetByIdAsync(id);
            if (statsCard == null) throw new NotFoundException("Stats Card notfound");
            await _repository.DeleteAsync(statsCard);
        }

        public async Task EditAsync(int id, StatsCardEditDto model)
        {
            var statsCard = await _repository.GetByIdAsync(id);
            if (statsCard == null) throw new NotFoundException("Stats Card notfound");
            statsCard.Value = model.Value;
            statsCard.IsPercent = model.IsPercent;
            statsCard.IconName = model.IconName;
            statsCard.Name = model.Name;
            await _repository.EditAsync(statsCard);
        }

        public async Task<IEnumerable<StatsCardDto>> GetAllAsync()
        {
            var statsCards = await _repository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<StatsCardDto>>(statsCards);
            return result;
        }

        public async Task<StatsCardDto> GetById(int id)
        {
            var statsCard = await _repository.GetByIdAsync(id);
            if (statsCard == null) throw new NotFoundException("Stats Card notfound");
            var result = _mapper.Map<StatsCardDto>(statsCard);
            return result;
        }
    }
}