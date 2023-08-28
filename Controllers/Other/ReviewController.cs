

//namespace OnlineMarket.Controllers.Other
//{
//    [Route("api/{controller}")]
//    [ApiController]
//    [Authorize] // Ensure the user is authenticated
//    public class ReviewController : ControllerBase
//    {
//        private readonly OnlineMarketDB _dbContext;
//        private readonly UserManager<User> _userManager;

//        public ReviewController(OnlineMarketDB dbContext, UserManager<User> userManager)
//        {
//            _dbContext = dbContext;
//            _userManager = userManager;
//        }

//        [HttpPost]
//        [Route("add")]
//        public async Task<IActionResult> AddReview([FromBody] AddReviewModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var user = await _userManager.GetUserAsync(User);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == model.ProductId);
//            if (product == null)
//            {
//                return NotFound("Product not found.");
//            }

//            var review = new Review
//            {
//                ProductId = product.ProductId,
//                UserId = user.Id,
//                ReviewText = model.ReviewText,
//                Rating = model.Rating,
//                ReviewDate = DateTime.Now
//            };

//            _dbContext.Reviews.Add(review);
//            _dbContext.SaveChanges();

//            return Ok("Review added successfully.");
//        }
//    }
//}
