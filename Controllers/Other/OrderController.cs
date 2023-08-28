
namespace OnlineMarket.Controllers.Other
{
    [Route("api/{controller}")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly OnlineMarketDB _dbContext;
        private readonly UserManager<User> _userManager;

        public OrderController(OnlineMarketDB dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        //[HttpPost]
        //public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = new Order
        //    {
        //        CustomerId = user.Id,
        //        OrderDate = DateTime.Now,
        //        Status = OrderStatus.Pending
        //    };

        //    foreach (var item in model.Items)
        //    {
        //        var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
        //        if (product != null)
        //        {
        //            var orderItem = new OrderItem
        //            {
        //                ProductId = product.ProductId,
        //                Quantity = item.Quantity,
        //                Subtotal = product.Price * item.Quantity
        //            };
        //            order.OrderItems.Add(orderItem);
        //        }
        //    }

        //    _dbContext.Orders.Add(order);
        //    _dbContext.SaveChanges();

        //    return Ok("Order placed successfully.");
        //}

    }
}
