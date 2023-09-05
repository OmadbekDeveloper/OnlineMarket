namespace OnlineMarket.Models.Dtos.Discount
{
    public class ResultDiscountDto
    {
        public int DiscountId { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
