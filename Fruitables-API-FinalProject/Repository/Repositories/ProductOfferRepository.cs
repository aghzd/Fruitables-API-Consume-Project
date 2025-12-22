using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class ProductOfferRepository : BaseRepository<ProductOffer>, IProductOfferRepository
    {
        public ProductOfferRepository(AppDbContext context) : base(context) { }
    }
}