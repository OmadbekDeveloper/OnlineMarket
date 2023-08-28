namespace OnlineMarket.Interfaces.Models
{
    public interface IReviewService
    {
        Task<List<Review>> GetReviewsByProductIdAsync(int productId);
        Task<Review> GetReviewByIdAsync(int id);
        Task<Review> AddReviewAsync(Review review);
        Task<bool> UpdateReviewAsync(int id, Review updatedReview);
        Task<bool> DeleteReviewAsync(int id);
        // Add more methods as needed
    }
}
