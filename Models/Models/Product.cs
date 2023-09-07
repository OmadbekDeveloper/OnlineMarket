
using System.ComponentModel.DataAnnotations;
using OnlineMarket.Interfaces.Person;

namespace OnlineMarket.Models.Models
{
    public class Product : IName
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, 10000)]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
