using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class StatsCardRepository : BaseRepository<StatsCard>, IStatsCardRepository
    {
        public StatsCardRepository(AppDbContext context) : base(context) { }
    }
}