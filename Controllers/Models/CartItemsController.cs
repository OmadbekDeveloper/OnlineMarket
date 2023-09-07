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

        [HttpGet("GetCartItemsByCartId")]
        public async Task<Responce<IEnumerable<ResultCartItemDto>>> GetCartItemsByCartId()
        {
            var cartitem = await cartItemService.GetCartItemAllAsync();

            return cartitem;
        } // done

        [HttpGet("GetCartItemById")]
        public async Task<Responce<ResultCartItemDto>> GetCartItemById(int id)
        {
            var getcartItemid = await cartItemService.GetCartItemByIdAsync(id);

            return getcartItemid;
        } // done

        [HttpPost("AddCartItem")]

        public async Task<Responce<ResultCartItemDto>> AddCartItem(CreateCartItemDto cartitemdto)
        {
           var createcartitem =  await cartItemService.AddCartItemAsync(cartitemdto);

            return createcartitem;
        } // done
        

        [HttpPut("UpdateCartItem")]
        public async Task<Responce<ResultCartItemDto>> UpdateCartItem(UpdateCartItemDto updateCartItemDto)
        {
            var updatecartitem = await cartItemService.UpdateCartItemAsync(updateCartItemDto);         

            return updatecartitem;
        }

        [HttpDelete("RemoveCartItem")]
        public async Task<Responce<bool>> RemoveCartItem(int id)
        {
            var deletecartitem = await cartItemService.RemoveCartItemAsync(id);

            return deletecartitem;
        }
    }
}