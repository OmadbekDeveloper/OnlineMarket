using OnlineMarket.Models.Models;

namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet("GetReviews")]
        public async Task<IActionResult> GetReviews()
        {
            var reviews = await reviewService.GetReviewsByProductIdAsync();
            if (reviews == null)
                return NotFound();

            return Ok(reviews);
        } // done

        [HttpGet("GetReview")]
        public async Task<IActionResult> GetReview(int id)
        {
            var review = await reviewService.GetReviewByIdAsync(id);
            if (review == null)
                return NotFound();

            return Ok(review);
        } // done

        [HttpPost("AddReview")]
        public async Task<IActionResult> AddReview(CreateReviewDto createReviewDto)
        {
            await reviewService.AddReviewAsync(createReviewDto);
            if(createReviewDto == null)
            {
                return NotFound();
            }

            return Ok("Added");
        } // done

        // Implement POST, PUT, and DELETE methods similarly
    }
}