namespace OnlineMarket.Models.Dtos.Discount
{
    public class UpdateDiscountDto
    {
        public int DiscounntId { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
