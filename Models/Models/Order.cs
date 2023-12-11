﻿namespace OnlineMarket.Models.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; internal set; }
        public string Statuss { get; set; }
        public OrderStatus Status { get; set; }


        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }


        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        public int? EmployeeId { get; set; }


        [ForeignKey(nameof(OrderItem))]
        public OrderItem OrderItem { get; set; }
        public int OrderItemId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
