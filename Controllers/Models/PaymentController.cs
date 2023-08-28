namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly OnlineMarketDB _context;

        public PaymentController(OnlineMarketDB context)
        {
            _context = context;
        }

        [HttpGet("{GetPayments}")]
        public async Task<IActionResult> GetPayments()
        {
            var payments = await _context.Payments.ToListAsync();
            return Ok(payments);
        }

        [HttpGet("{GetPayment}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        // Implement POST, PUT, and DELETE methods similarly
    }
}