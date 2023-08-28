// DONE
namespace OnlineMarket.Controllers.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartsController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet("{GetAllCarts}")]
        public async Task<IActionResult> GetAllCarts()
        {
            var getcarts = cartService.GetAllCartsAsync();
            if (getcarts == null)
                return NotFound();

            return Ok(getcarts);
        }

        [HttpGet("{GetCart}")]
        public async Task<IActionResult> GetCart(int id)
        {
            var getcart = cartService.GetCartByIdAsync(id);
            if (getcart == null)
                return NotFound();

            return Ok(getcart);
        }

        [HttpPost("{CreateCart}")]
        public async Task<IActionResult> CreateCart(int CartId)
        {
            var createcart = cartService.CreateCartAsync(CartId);
            if (createcart == null)
                return NotFound();

            return Ok(createcart);
        }

        [HttpPut("{UpdateCart}")]
        public async Task<IActionResult> UpdateCart(int id, Cart updatedCart)
        {
            var updatecart = cartService.UpdateCartAsync(id, updatedCart);
            if (updatecart == null)
                return NotFound();

            return Ok(updatecart);
        }

        [HttpDelete("{DeleteCart}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var deletecart = cartService.DeleteCartAsync(id);
            if (deletecart == null)
                return NotFound();

            return Ok(deletecart);
        }

        [HttpGet("{CalculateCartTotal}")]
        public async Task<IActionResult> CalculateCartTotal(int id)
        {
            var calculatecart = cartService.CalculateCartTotalAsync(id);
            if (calculatecart == null)
                return NotFound();

            return Ok(calculatecart);
        }
    }
}