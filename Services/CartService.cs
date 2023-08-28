// DONE


public class CartService : ICartService
{
    private readonly OnlineMarketDB _context;

    public CartService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<Cart>> GetAllCartsAsync()
    {
        return await _context.Carts
            .Include(c => c.CartItems)
            .ToListAsync();
    }

    public async Task<Cart> GetCartByIdAsync(int id)
    {
        return await _context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.CartId == id);
    }

    public async Task<Cart> CreateCartAsync(int cartid)
    {
        var existingCart = await _context.Carts.FirstOrDefaultAsync(cart => cart.CustomerId == cartid);

        if (existingCart != null)
        {
            throw new Exception("User already has a cart.");
        }

        var newCart = new Cart
        {
            CustomerId = cartid
            
        };

        await _context.Carts.AddAsync(newCart);
        await _context.SaveChangesAsync();

        return newCart;
    }

    public async Task<bool> UpdateCartAsync(int id, Cart updatedCart)
    {
        var cart = await _context.Carts.FindAsync(id);

        if (cart == null)
        {
            throw new Exception("Cart not found.");
            return false;
        }

        cart.CustomerId = updatedCart.CustomerId;

        _context.Carts.Update(cart);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCartAsync(int id)
    {
        var cart = await _context.Carts.FindAsync(id);

        if (cart == null)
        {
            throw new Exception("Cart not found.");
            return false;
        }

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<decimal> CalculateCartTotalAsync(int id)
    {
        var cartItems = await _context.CartItems
            .Where(item => item.CartId == id)
            .Include(item => item.Product)
            .ToListAsync();

        if (cartItems == null)
            throw new ArgumentException("Invalid cart Id. ");


        decimal total = cartItems.Sum(item => item.Quantity * item.Product.Price);
        return total;
    }
}
