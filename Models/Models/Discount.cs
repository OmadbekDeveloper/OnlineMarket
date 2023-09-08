namespace OnlineMarket.Models.Models
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public DateTime ExpiryDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
