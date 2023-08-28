namespace OnlineMarket.Interfaces.Models
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetOrderItemsByOrderIdAsync();
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
        Task<bool> UpdateOrderItemAsync(int id, OrderItem updatedOrderItem);
        Task<bool> RemoveOrderItemAsync(int id);
        // Add more methods as needed
    }
}
