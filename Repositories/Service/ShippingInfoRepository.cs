namespace OnlineMarket.Repositories.Service
{
    public class ShippingInfoRepository : GenericRepository<ShippingInfo>, IShippingInfoRepository
    {
        public ShippingInfoRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }
    }
}
