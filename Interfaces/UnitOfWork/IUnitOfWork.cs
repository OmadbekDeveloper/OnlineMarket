
namespace OnlineMarket.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICartRepository CartRepository { get; }
        ICartItemRepository CartItemRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICustomerRepository CustomerRepository { get;  }
        IDiscountRepository DiscountRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        INotificationRepository NotificationRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IProductCategoryRepository ProductCategoryRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IShippingInfoRepository ShippingInfoRepository { get; }
        Task<int> SaveAsync();

    }
}
