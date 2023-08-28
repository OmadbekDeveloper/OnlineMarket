using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Models.Other
{
    public class PlaceOrderModel
    {
        [Required]
        public List<OrderItemModel> Items { get; set; }
    }

    public class OrderItemModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }
    }

    // Other models for tracking order history and status
}
