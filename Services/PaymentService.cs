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

    public async Task CreatePaymentAsync(CreatePaymentDto createPaymentDto)
    {
        var paymentcreate = new Payment()
        {
            PaymentId = createPaymentDto.PaymentId,
            OrderId = createPaymentDto.OrderId,
            PaymentDate = createPaymentDto.PaymentDate,
            Amount = createPaymentDto.Amount,
            PaymentMethod = createPaymentDto.PaymentMethod,
        };

        await _context.Payments.AddAsync(paymentcreate);
        await _context.SaveChangesAsync();
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
