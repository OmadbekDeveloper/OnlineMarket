// Done
using OnlineMarket.Interfaces.Models;
using OnlineMarket.Models.Models;

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

        [HttpGet("GetCartItemsByCartId")]
        public async Task<IActionResult> GetCartItemsByCartId()
        {
            var cartitem = await cartItemService.GetCartItemsByCartIdAsync();
            if (cartitem == null)
                return NotFound();

            return Ok(cartitem);
        } // done

        [HttpGet("GetCartItemById")]
        public async Task<IActionResult> GetCartItemById(int id)
        {
            var getcartItemid = await cartItemService.GetCartItemByIdAsync(id);
            if (getcartItemid == null)
                return NotFound();

            return Ok(getcartItemid);
        } // done

        [HttpPost("AddCartItem")]

        public async Task<IActionResult> AddCartItem([FromForm] CreateCartItemDto cartitemdto)
        {
            await cartItemService.AddCartItemAsync(cartitemdto);

            return Ok("Created");
        } // done
        

        [HttpPut("UpdateCartItem")]
        public async Task<IActionResult> UpdateCartItem(int id, CartItem updatedCartItem)
        {
            var updatecartitem = cartItemService.UpdateCartItemAsync(id, updatedCartItem);
            if (updatecartitem == null)
                return NotFound();

            return Ok(updatecartitem);
        }

        [HttpDelete("RemoveCartItem")]
        public async Task<IActionResult> RemoveCartItem(int id)
        {
            var deletecartitem = cartItemService.RemoveCartItemAsync(id);
            if (deletecartitem == null)
                return NotFound();

            return Ok(deletecartitem);
        }
    }
}