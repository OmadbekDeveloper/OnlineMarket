namespace OnlineMarket.Repositories.Service
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }

    }
}