﻿namespace OnlineMarket.Models.Dtos.ShippingInfo
{
    public class ResultShippingInfoDto
    {
        public int ShippingInfoId { get; set; }
        public int OrderId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
