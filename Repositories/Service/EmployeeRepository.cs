
namespace OnlineMarket.Repositories.Service
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }

    }
}
