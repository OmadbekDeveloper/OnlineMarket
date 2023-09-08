using OnlineMarket.Interfaces.Person;

namespace OnlineMarket.Models.Models
{
    public class Category : IName
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
