namespace OnlineMarket.Models.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Ratings { get; set; }

        public Product Product { get; set; }
        public ReviewRating Rating { get; set; }

    }
}
