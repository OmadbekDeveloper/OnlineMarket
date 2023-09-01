

public class ReviewService : IReviewService
{
    private readonly OnlineMarketDB _context;

    public ReviewService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<Review>> GetReviewsByProductIdAsync()
    {
        return await _context.Reviews.ToListAsync();
    } // done

    public async Task<Review> GetReviewByIdAsync(int id)
    {
        return await _context.Reviews.FindAsync(id);
    } // done

    public async Task AddReviewAsync(CreateReviewDto createReviewDto)
    {
        var reviewcreate = new Review()
        {
             ReviewId = createReviewDto.ReviewId,
             ProductId = createReviewDto.ProductId,
             UserId = createReviewDto.UserId,
             ReviewText = createReviewDto.ReviewText,
             ReviewDate = createReviewDto.ReviewDate,
             Ratings = createReviewDto.Ratings,
        };

        await _context.Reviews.AddAsync(reviewcreate);
        await _context.SaveChangesAsync();
    } // done

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
