namespace OnlineMarket.Models.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
