using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Models.Models
{
    public class CartItem
    {
        [Key] 
        public int CartItemId { get; set; }       
        public int Quantity { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }
        public int CartId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
