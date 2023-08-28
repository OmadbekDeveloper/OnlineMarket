// DONE
using Microsoft.EntityFrameworkCore;

public class PaymentService : IPaymentService
{
    private readonly OnlineMarketDB _context;

    public PaymentService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<Payment>> GetAllPaymentsAsync()
    {
        return await _context.Payments.ToListAsync();
    } // done

    public async Task<Payment> GetPaymentByIdAsync(int id)
    {
        return await _context.Payments.FindAsync(id);
    } // done

    public async Task<Payment> CreatePaymentAsync(int OrderId, Payment payment)
    {
        var existingOrder = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == OrderId);

        if (existingOrder == null)
        {
            throw new Exception("Order not found.");
        }
        payment.PaymentDate = DateTime.Now;
        existingOrder.PaymentId=payment.PaymentId;

        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();

        return payment;
    }

    public async Task<bool> UpdatePaymentAsync(int id, Payment payment)
    {
        var existingPayment = await _context.Payments.FindAsync(id, payment.PaymentId);

        if (existingPayment == null)
        {
            throw new Exception("Payment not found.");
            return false;
        }

        existingPayment.Amount = payment.Amount;
        existingPayment.PaymentMethod = payment.PaymentMethod;

        _context.Payments.Update(existingPayment);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePaymentAsync(int id)
    {
        var payment = await _context.Payments.FindAsync(id);

        if (payment == null)
        {
            throw new Exception("Payment not found.");
            return false;
        }

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
        return true;
    }
}
