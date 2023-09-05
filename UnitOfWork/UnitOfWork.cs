using OnlineMarket.Interfaces.Repasitories.Services;

namespace OnlineMarket.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineMarketDB _dbContext;
        private IProductRepository _productRepository;
        private ICartReposiitory _cartReposiitory;
        private ICartItemRepository _cartitemRepository;
        private ICategoryRepository _categoryRepository;
        private ICustomerRepository _customerRepository;
        private IDiscountRepository _discountRepository;
        private IEmployeeRepository _employeeRepository;
        private INotificationRepository _notificationRepository;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        private IPaymentRepository _paymentRepository;
        private IProductCategoryRepository _productCategoryRepository;
        private IReviewRepository _reviewRepository;
        private IShippingInfoRepository _shippingInfoRepository;




        public UnitOfWork(OnlineMarketDB dbContext)
        {
            _dbContext = dbContext;
        }


        public IProductRepository ProductRepository
        {
            get { return _productRepository = _productRepository ?? new ProductRepository(_dbContext); }
        }

        public ICartReposiitory CartReposiitory
        {
            get { return _cartReposiitory = _cartReposiitory ?? new CartRepository(_dbContext); }
        }

        public ICartItemRepository CartItemRepository
        {
            get { return _cartitemRepository = _cartitemRepository ?? new CartItemRepository(_dbContext); }
        }

        public ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository = _categoryRepository ?? new CategoryRepository(_dbContext); }
        }

        public ICustomerRepository CustomerRepository
        {
            get { return _customerRepository = _customerRepository ?? new CustomerRepository(_dbContext); }
        }

        public IDiscountRepository DiscountRepository
        {
            get { return _discountRepository = _discountRepository ?? new DiscountRepository(_dbContext); }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get { return _employeeRepository = _employeeRepository ?? new EmployeeRepository(_dbContext); }
        }

        public INotificationRepository NotificationRepository
        {
            get { return _notificationRepository = _notificationRepository ?? new NotificationRepository(_dbContext); }
        }

        public IOrderRepository OrderRepository
        {
            get { return _orderRepository = _orderRepository ?? new OrderRepository(_dbContext); }
        }

        public IOrderItemRepository OrderItemRepository
        {
            get { return _orderItemRepository = _orderItemRepository ?? new OrderItemRepository(_dbContext); }
        }

        public IPaymentRepository PaymentRepository
        {
            get { return _paymentRepository = _paymentRepository ?? new PaymentRepository(_dbContext); }
        }

        public IProductCategoryRepository ProductCategoryRepository
        {
            get { return _productCategoryRepository = _productCategoryRepository ?? new ProductCategoryRepository(_dbContext); }
        }

        public IReviewRepository ReviewRepository   
        {
            get { return _reviewRepository = _reviewRepository   ?? new ReviewRepository(_dbContext); }
        }

        public IShippingInfoRepository ShippingInfoRepository
        {
            get { return _shippingInfoRepository = _shippingInfoRepository ?? new ShippingInfoRepository(_dbContext); }
        }


        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
