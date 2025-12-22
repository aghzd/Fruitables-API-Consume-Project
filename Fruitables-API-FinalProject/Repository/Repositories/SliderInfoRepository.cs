using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class SliderInfoRepository : BaseRepository<SliderInfo>, ISliderInfoRepository
    {
        public SliderInfoRepository(AppDbContext context) : base(context) { }
    }
}