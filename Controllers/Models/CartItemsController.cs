// Done
namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemService cartItemService;

        public CartItemsController(ICartItemService cartItemService)
        {
            this.cartItemService = cartItemService;
        }

        [HttpGet("{GetCartItemsByCartId}")]
        public async Task<IActionResult> GetCartItemsByCartId()
        {
            var getcartitem = cartItemService.GetCartItemsByCartIdAsync();
            if (getcartitem == null)
                return NotFound();

            return Ok(getcartitem);
        }

        [HttpGet("{GetCartItemById}")]
        public async Task<IActionResult> GetCartItemById(int id)
        {
            var getcartItemid = cartItemService.GetCartItemByIdAsync(id);
            if (getcartItemid == null)
                return NotFound();

            return Ok(getcartItemid);
        }

        [HttpPost("{AddCartItem}")]
        public async Task<IActionResult> AddCartItem(CartItem cartItem)
        {
            var addcartitem = cartItemService.AddCartItemAsync(cartItem);
            if (addcartitem == null)
                return NotFound();

            return Ok(addcartitem);
        }

        [HttpPut("{UpdateCartItem}")]
        public async Task<IActionResult> UpdateCartItem(int id, CartItem updatedCartItem)
        {
            var updatecartitem = cartItemService.UpdateCartItemAsync(id, updatedCartItem);
            if (updatecartitem == null)
                return NotFound();

            return Ok(updatecartitem);
        }

        [HttpDelete("{RemoveCartItem}")]
        public async Task<IActionResult> RemoveCartItem(int id)
        {
            var deletecartitem = cartItemService.RemoveCartItemAsync(id);
            if (deletecartitem == null)
                return NotFound();

            return Ok(deletecartitem);
        }
    }
}