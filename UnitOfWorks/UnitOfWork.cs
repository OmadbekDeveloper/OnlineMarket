
namespace OnlineMarket.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineMarketDB _dbContext;

        public UnitOfWork(OnlineMarketDB dbContext)
        {
            _dbContext = dbContext;

            ProductRepository = new ProductRepository(dbContext);
            CartRepository = new CartRepository(dbContext);
            CartItemRepository = new CartItemRepository(dbContext);
            CategoryRepository = new CategoryRepository(dbContext);
            CustomerRepository = new CustomerRepository(dbContext);
            DiscountRepository = new DiscountRepository(dbContext);
            EmployeeRepository = new EmployeeRepository(dbContext);
            NotificationRepository = new NotificationRepository(dbContext);
            OrderRepository = new OrderRepository(dbContext);
            OrderItemRepository = new OrderItemRepository(dbContext);
            PaymentRepository = new PaymentRepository(dbContext);
            ProductCategoryRepository = new ProductCategoryRepository(dbContext);
            ReviewRepository = new ReviewRepository(dbContext);
            ShippingInfoRepository = new ShippingInfoRepository(dbContext);

        }

        public IProductRepository ProductRepository { get; }
        public ICartRepository CartRepository { get; }
        public ICartItemRepository CartItemRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IDiscountRepository DiscountRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }
        public INotificationRepository NotificationRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderItemRepository OrderItemRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IProductCategoryRepository ProductCategoryRepository { get; }
        public IReviewRepository ReviewRepository { get; }
        public IShippingInfoRepository ShippingInfoRepository { get; }

        public async Task<int> SaveAsync()
        => await _dbContext.SaveChangesAsync();

    }
}
