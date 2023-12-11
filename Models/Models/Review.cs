using OnlineMarket.Models.User;
namespace OnlineMarket.Models.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }


        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int ProductId { get; set; }


        [ForeignKey(nameof(Ratings))]
        public ReviewRating Rating { get; set; }
        public int Ratings { get; set; }


        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
