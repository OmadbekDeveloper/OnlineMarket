namespace OnlineMarket.Models.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }

    }
}
