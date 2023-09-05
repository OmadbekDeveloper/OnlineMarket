namespace OnlineMarket.Models.Dtos.CartItem
{
    public class UpdateCartItemDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
