
namespace OnlineMarket.Repositories.Service
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }
    }
}
