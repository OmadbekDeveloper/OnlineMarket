namespace OnlineMarket.Interfaces.Models
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetOrderItemsByOrderIdAsync();
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        Task AddOrderItemAsync(CreateOrderItemDto orderItemdto);
        Task<bool> UpdateOrderItemAsync(int id, OrderItem updatedOrderItem);
        Task<bool> RemoveOrderItemAsync(int id);
        // Add more methods as needed
    }
}
