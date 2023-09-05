

namespace OnlineMarket.Repositories.Service
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }
    }
}
