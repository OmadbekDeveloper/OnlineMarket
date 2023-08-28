namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly OnlineMarketDB _context;

        public DiscountsController(OnlineMarketDB context)
        {
            _context = context;
        }

        [HttpGet("{GetDiscounts}")]
        public async Task<IActionResult> GetDiscounts()
        {
            var discounts = await _context.Discounts.ToListAsync();
            return Ok(discounts);
        }

        [HttpGet("{GetDiscount}")]
        public async Task<IActionResult> GetDiscount(int id)
        {
            var discount = await _context.Discounts.FindAsync(id);
            if (discount == null)
                return NotFound();

            return Ok(discount);
        }

        // Implement POST, PUT, and DELETE methods similarly
    }
}