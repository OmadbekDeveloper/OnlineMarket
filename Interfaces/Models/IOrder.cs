using System.Threading.Tasks;

namespace OnlineMarket.Interfaces.Models
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(Order order);
        Task<bool> UpdateOrderAsync(int id, Order updatedOrder);
        Task<bool> DeleteOrderAsync(int id);
        Task<decimal> CalculateOrderTotalAsync(int id);
        Task<bool> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus);
        // Add more methods as needed
    }
}
