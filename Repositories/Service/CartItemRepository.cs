
namespace OnlineMarket.Repositories.Service
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }

        public async Task<CartItem> GetByIdAsync(int id)
        {
            return await _dbContext.CartItems.FirstOrDefaultAsync(p => p.CartItemId == id);
        }

    }
}
