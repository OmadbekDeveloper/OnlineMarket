
namespace OnlineMarket.Repositories.Service
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }

    }
}
