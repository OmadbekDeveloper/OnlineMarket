using OnlineMarket.Models.Dtos.OrderItem;

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
    } // done

    public async Task<OrderItem> GetOrderItemByIdAsync(int id)
    {
        return await _context.OrderItems.FindAsync(id);
    } // done

    public async Task AddOrderItemAsync(CreateOrderItemDto orderItemdto)
    {
        var orderitemrcreate = new OrderItem()
        {
            OrderItemId = orderItemdto.OrderId,
            OrderId = orderItemdto.OrderId,
            ProductId = orderItemdto.ProductId,
            Quantity = orderItemdto.Quantity,
            Subtotal = orderItemdto.Subtotal,
        };

        await _context.OrderItems.AddAsync(orderitemrcreate);
        await _context.SaveChangesAsync();
    } // done?

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
