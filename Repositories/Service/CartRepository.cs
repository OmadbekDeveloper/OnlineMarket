
namespace OnlineMarket.Repositories.Service
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }

        public async Task<Cart> GetByIdAsync(int id)
        {
            return await _dbContext.Carts.FirstOrDefaultAsync(p => p.CartId == id);
        }
    }
}
