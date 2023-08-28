
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

    public async Task<Order> CreateOrderAsync(Order order)
    {
        var existingCustomer = await _context.Customers.FindAsync(order.CustomerId);
        var existingEmployee = order.EmployeeId.HasValue ? await _context.Employees.FindAsync(order.EmployeeId.Value) : null;
        var existingPayment = await _context.Payments.FindAsync(order.PaymentId);

        if (existingCustomer == null)
        {
            throw new Exception("Customer not found.");
        }

        order.OrderDate = DateTime.Now;
        order.Status = OrderStatus.Pending;

        order.OrderTotal = order.OrderItems.Sum(item => item.Product.Price * item.Quantity);

        if (existingEmployee != null)
        {
            order.Employee = existingEmployee;
        }

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        return order;
    }

    public async Task<bool> UpdateOrderAsync(int id, Order updatedOrder)
    {
        var existingOrder = await _context.Orders.FindAsync(id);

        if (existingOrder == null)
        {
            throw new Exception("Order not found.");
            return false;
        }

        existingOrder.Status = updatedOrder.Status;
        existingOrder.Payment = updatedOrder.Payment;

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
