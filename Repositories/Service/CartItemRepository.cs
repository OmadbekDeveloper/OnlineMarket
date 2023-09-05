namespace OnlineMarket.Repositories.Service
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }
    }
}
