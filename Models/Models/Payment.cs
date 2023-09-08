namespace OnlineMarket.Models.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        public int OrderId { get; set; }

    }
}
