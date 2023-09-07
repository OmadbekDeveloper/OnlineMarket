
namespace OnlineMarket.Repositories.Service
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }
    }
}
