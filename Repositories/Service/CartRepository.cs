namespace OnlineMarket.Repositories.Service
{
    public class CartRepository : GenericRepository<Cart>, ICartReposiitory
    {
        public CartRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }
    }
}
