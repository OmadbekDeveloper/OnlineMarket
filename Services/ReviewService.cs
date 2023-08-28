

public class ReviewService : IReviewService
{
    private readonly OnlineMarketDB _context;

    public ReviewService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<Review>> GetReviewsByProductIdAsync(int productId)
    {
        return await _context.Reviews
            .Where(r => r.ProductId == productId)
            .ToListAsync();
    }

    public async Task<Review> GetReviewByIdAsync(int id)
    {
        return await _context.Reviews.FindAsync(id);
    }

    public async Task<Review> AddReviewAsync(Review review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        return review;
    }

    public async Task<bool> UpdateReviewAsync(int id, Review updatedReview)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review == null)
            return false;

        _context.Entry(review).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteReviewAsync(int id)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review == null)
            return false;

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
        return true;
    }
}
