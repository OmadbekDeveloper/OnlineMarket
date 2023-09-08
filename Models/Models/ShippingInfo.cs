namespace OnlineMarket.Models.Models
{
    public class ShippingInfo
    {
        [Key]
        public int ShippingInfoId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        public int OrderId { get; set; }

    }
}
