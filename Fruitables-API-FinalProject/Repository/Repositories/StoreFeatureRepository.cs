using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class StoreFeatureRepository : BaseRepository<StoreFeature>, IStoreFeatureRepository
    {
        public StoreFeatureRepository(AppDbContext context) : base(context) { }
    }
}
