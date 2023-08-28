
//namespace OnlineMarket.Controllers
//{
//    [Route("api/{controller}")]
//    [ApiController]
//    [Authorize] // Ensure the user is authenticated
//    public class ShoppingCartController : ControllerBase
//    {
//        private readonly OnlineMarketDB _dbContext;
//        private readonly UserManager<User> _userManager;

//        public ShoppingCartController(OnlineMarketDB dbContext, UserManager<User> userManager)
//        {
//            _dbContext = dbContext;
//            _userManager = userManager;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetShoppingCart()
//        {
//            var user = await _userManager.GetUserAsync(User);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            var shoppingCart = GetShoppingCartFromDatabase(user.Id);

//            return Ok(shoppingCart);
//        }

//        [HttpPost("add")]
//        public async Task<IActionResult> AddToCart([FromBody] AddToCartModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var user = await _userManager.GetUserAsync(User);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            AddProductToShoppingCart(user.Id, model.ProductId, model.Quantity);

//            return Ok("Product added to cart.");
//        }

//        private List<ShoppingCartItem> GetShoppingCartFromDatabase(int userId)
//        {
//            var shoppingCartItems = _dbContext.ShoppingCartItems
//                .Include(item => item.Product) // Load related product data
//                .Where(item => item.UserId == userId)
//                .ToList();

//            return shoppingCartItems;
//        }


//        private void AddProductToShoppingCart(int userId, int productId, int quantity)
//        {
//            var existingCartItem = _dbContext.ShoppingCartItems
//                .FirstOrDefault(item => item.UserId == userId && item.ProductId == productId);

//            if (existingCartItem != null)
//            {
//                existingCartItem.Quantity += quantity;
//            }
//            else
//            {
//                var cartItem = new ShoppingCartItem
//                {
//                    UserId = userId,
//                    ProductId = productId,
//                    Quantity = quantity
//                };
//                _dbContext.ShoppingCartItems.Add(cartItem);
//            }

//            _dbContext.SaveChanges();
//        }
//    }
//}
