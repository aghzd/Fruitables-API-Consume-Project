using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class SliderImageRepository : BaseRepository<SliderImage>, ISliderImageRepository
    {
        public SliderImageRepository(AppDbContext context) : base(context) { }
    }
}