namespace OnlineMarket.Models.Dtos.Review
{
    public class UpdateReviewDto
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Ratings { get; set; }
    }
}
