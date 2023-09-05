namespace OnlineMarket.Models.Dtos.Order
{
    public class CreateOrderDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Statuss { get; set; }
        public decimal OrderTotal { get; internal set; }
    }
}
