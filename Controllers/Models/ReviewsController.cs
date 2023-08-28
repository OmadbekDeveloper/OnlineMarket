using OnlineMarket.Models.Models;

namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly OnlineMarketDB _context;

        public ReviewsController(OnlineMarketDB context)
        {
            _context = context;
        }

        [HttpGet("{GetReviews}")]
        public async Task<IActionResult> GetReviews()
        {
            var reviews = await _context.Reviews.ToListAsync();
            if (reviews == null)
                return NotFound();

            return Ok(reviews);
        } // done

        [HttpGet("{GetReview}")]
        public async Task<IActionResult> GetReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
                return NotFound();

            return Ok(review);
        } // done

        // Implement POST, PUT, and DELETE methods similarly
    }
}