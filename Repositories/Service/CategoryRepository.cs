
namespace OnlineMarket.Repositories.Service
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }
    }
}
