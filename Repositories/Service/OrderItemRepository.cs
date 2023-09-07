
namespace OnlineMarket.Repositories.Service
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }
    }
}
