namespace OnlineMarket.Models.Dtos.Payment
{
    public class UpdatePaymentDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
