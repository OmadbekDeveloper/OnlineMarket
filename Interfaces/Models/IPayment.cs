namespace OnlineMarket.Interfaces.Models
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetAllPaymentsAsync();
        Task<Payment> GetPaymentByIdAsync(int id);
        Task<Payment> CreatePaymentAsync(int orderId, Payment payment);
        Task<bool> UpdatePaymentAsync(int id, Payment updatedPayment);
        Task<bool> DeletePaymentAsync(int id);
        // Add more methods as needed
    }
}
