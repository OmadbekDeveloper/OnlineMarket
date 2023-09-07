
namespace OnlineMarket.Repositories.Service
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }
    }
}
