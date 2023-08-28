
public class OrderService : IOrderService
{
    private readonly OnlineMarketDB _context;

    public OrderService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders.ToListAsync();
    } // done

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await _context.Orders.FindAsync(id);
    } // done

    public async Task CreateOrderAsync(CreateOrderDto orderdto)
    {
        var ordercreate = new Order()
        {
            OrderId = orderdto.OrderId,
            CustomerId = orderdto.CustomerId,
            EmployeeId = orderdto.EmployeeId,
            OrderDate = orderdto.OrderDate,
            Statuss = orderdto.Statuss,
            OrderTotal = orderdto.OrderTotal,
        };

        await _context.Orders.AddAsync(ordercreate);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateOrderAsync(int id, Order updatedOrder)
    {
        var existingOrder = await _context.Orders.FindAsync(id);

        if (existingOrder == null)
        {
            throw new Exception("Order not found.");
            return false;
        }

       

        _context.Orders.Update(existingOrder);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
        {
            throw new Exception("Order not found.");
            return false;
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<decimal> CalculateOrderTotalAsync(int id)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.OrderId == id);

        if (order == null)
        {
            throw new Exception("Order not found.");
        }

        decimal total = order.OrderItems.Sum(item => item.Product.Price * item.Quantity);
        return total;
    }

    public async Task<bool> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus)
    {
        var order = await _context.Orders.FindAsync(orderId);

        if (order == null)
        {
            throw new Exception("Order not found.");
            return false;
        }

        order.Status = newStatus;

        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return true;
    }
}
