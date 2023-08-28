using OnlineMarket.Models.Models;

namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService orderItemService;

        public OrderItemsController(IOrderItemService orderItemService)
        {
            this.orderItemService = orderItemService;
        }

        [HttpGet("GetOrderItems")]
        public async Task<IActionResult> GetOrderItems()
        {
            var orderItems = await orderItemService.GetOrderItemsByOrderIdAsync();
            if (orderItems == null)
                return NotFound();

            return Ok(orderItems);
        } // done?

        [HttpGet("GetOrderItem")]
        public async Task<IActionResult> GetOrderItem(int id)
        {
            var orderItem = await orderItemService.GetOrderItemByIdAsync(id);
            if (orderItem == null)
                return NotFound();

            return Ok(orderItem);
        } // done?

        [HttpPost("CreateOrderItem")]
        public async Task<IActionResult> CreateOrderItem(CreateOrderItemDto orderItemdto)
        {
            await orderItemService.AddOrderItemAsync(orderItemdto);

            return Ok("Created");
        } // done?

    }
}