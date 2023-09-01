namespace OnlineMarket.Interfaces.Models
{
    public interface IReviewService
    {
        Task<List<Review>> GetReviewsByProductIdAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task AddReviewAsync(CreateReviewDto createReviewDto);
        Task<bool> UpdateReviewAsync(int id, Review updatedReview);
        Task<bool> DeleteReviewAsync(int id);
        // Add more methods as needed
    }
}
