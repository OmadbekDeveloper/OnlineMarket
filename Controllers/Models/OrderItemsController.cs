namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly OnlineMarketDB _context;

        public OrderItemsController(OnlineMarketDB context)
        {
            _context = context;
        }

        [HttpGet("{GetOrderItems}")]
        public async Task<IActionResult> GetOrderItems()
        {
            var orderItems = await _context.OrderItems.ToListAsync();
            return Ok(orderItems);
        }

        [HttpGet("{GetOrderItem}")]
        public async Task<IActionResult> GetOrderItem(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
                return NotFound();

            return Ok(orderItem);
        }

        [HttpPost("{CreateOrderItem}")]
        public async Task<IActionResult> CreateOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrderItem), new { id = orderItem.OrderItemId }, orderItem);
        }

        [HttpPut("{UpdateOrderItem}")]
        public async Task<IActionResult> UpdateOrderItem(int id, OrderItem updatedOrderItem)
        {
            if (id != updatedOrderItem.OrderItemId)
                return BadRequest();

            _context.Entry(updatedOrderItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{DeleteOrderItem}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
                return NotFound();

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}