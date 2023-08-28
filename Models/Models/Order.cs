namespace OnlineMarket.Models.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public int PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Statuss { get; set; }

        public OrderStatus Status { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Payment Payment { get; set; }
        public decimal OrderTotal { get; internal set; }
    }
}
