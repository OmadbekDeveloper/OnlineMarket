namespace OnlineMarket.Repositories.Service
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }
    }
}
