// DONE
public class OrderItemService : IOrderItemService
{
    private readonly OnlineMarketDB _context;

    public OrderItemService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<OrderItem>> GetOrderItemsByOrderIdAsync()
    {
        return await _context.OrderItems.ToListAsync();
    }

    public async Task<OrderItem> GetOrderItemByIdAsync(int id)
    {
        return await _context.OrderItems.FindAsync(id);
    }

    public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
    {
        var existingOrder = await _context.Orders.FindAsync(orderItem.OrderId);
        var existingProduct = await _context.Products.FindAsync(orderItem.ProductId);

        if (existingOrder == null || existingProduct == null)
        {
            throw new Exception("Order or product not found.");
        }

        orderItem.Subtotal = existingProduct.Price * orderItem.Quantity;

        await _context.OrderItems.AddAsync(orderItem);
        await _context.SaveChangesAsync();

        return orderItem;
    }

    public async Task<bool> UpdateOrderItemAsync(int id, OrderItem updatedOrderItem)
    {
        var existingOrderItem = await _context.OrderItems.FindAsync(id);

        if (existingOrderItem == null)
        {
            throw new Exception("Order item not found.");
            return false;
        }

        existingOrderItem.Quantity = updatedOrderItem.Quantity;
        existingOrderItem.Subtotal = existingOrderItem.Product.Price * updatedOrderItem.Quantity;  // Update the subtotal

        _context.OrderItems.Update(existingOrderItem);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveOrderItemAsync(int id)
    {
        var orderItem = await _context.OrderItems.FindAsync(id);

        if (orderItem == null)
        {
            throw new Exception("Order item not found.");
            return false;
        }

        _context.OrderItems.Remove(orderItem);
        await _context.SaveChangesAsync();
        return true;
    }
}
