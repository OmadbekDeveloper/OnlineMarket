// DONE
using OnlineMarket.Interfaces.Models;
using OnlineMarket.Models.Dtos.Cart;
using OnlineMarket.Models.Models;

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

        [HttpGet("GetAllCarts")]
        public async Task<Responce<IEnumerable<UniversalCartDto>>> GetAllCarts()
        {
            var getcarts = await cartService.GetAllCartsAsync();

            return getcarts;
        } // done

        [HttpGet("GetCart")]
        public async Task<Responce<UniversalCartDto>> GetCart(int id)
        {
            var getcart = await cartService.GetCartByIdAsync(id);

            return getcart;
        } // done

        [HttpPost("CreateCart")]
        public async Task<Responce<UniversalCartDto>> CreateCart(UniversalCartDto createCartDto)
        {
            var createcart = await cartService.CreateCartAsync(createCartDto);

            return createcart;
        } // done

        [HttpDelete("DeleteCart")]
        public async Task<Responce<bool>> DeleteCart(int id)
        {
            var deletecart = await cartService.DeleteCartAsync(id);

            return deletecart;
        }
    }
}