using OnlineMarket.Models.Dtos.Order;
using OnlineMarket.Models.Models;

namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("{GetOrders}")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await orderService.GetAllOrdersAsync();
            if (orders == null)
                return NotFound();

            return Ok(orders);
        } // done

        [HttpGet("{GetOrder}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        } // done

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createorderdto)
        {
            await orderService.CreateOrderAsync(createorderdto);

            return Ok("Created");
        } // done?

    }
}