namespace OnlineMarket.Models.Dtos.OrderItem
{
    public class UpdateOrderItemDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
