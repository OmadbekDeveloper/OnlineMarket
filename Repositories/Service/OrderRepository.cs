
namespace OnlineMarket.Repositories.Service
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }
    }
}
