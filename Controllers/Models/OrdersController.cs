using OnlineMarket.Models.Models;

namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OnlineMarketDB _context;

        public OrdersController(OnlineMarketDB context)
        {
            _context = context;
        }

        [HttpGet("{GetOrders}")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            if (orders != null)
                return NotFound();

            return Ok(orders);
        } // done

        [HttpGet("{GetOrder}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
                return NotFound();

            return Ok(order);
        } // done

        // Implement POST, PUT, and DELETE methods similarly
    }
}