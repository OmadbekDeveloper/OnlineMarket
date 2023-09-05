namespace OnlineMarket.Repositories.Service
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }
    }
}
