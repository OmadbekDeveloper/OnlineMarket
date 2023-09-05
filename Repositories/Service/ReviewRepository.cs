namespace OnlineMarket.Repositories.Service
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }
    }
}
