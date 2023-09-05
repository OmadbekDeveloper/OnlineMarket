using OnlineMarket.Models.Dtos.Cart;

public class CartService : ICartService
{
    private readonly OnlineMarketDB _context;

    public CartService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<Cart>> GetAllCartsAsync()
    {
        return await _context.Carts.ToListAsync();
    } // done

    public async Task<Cart> GetCartByIdAsync(int id)
    {
        return await _context.Carts.FindAsync(id);
    } // done

    public async Task CreateCartAsync(UniversalCartDto cartdto)
    {
        var cartcreate = new Cart()
        {
            CartId = cartdto.CartId,
            CustomerId = cartdto.CustomerId,
        };

        await _context.Carts.AddAsync(cartcreate);
        await _context.SaveChangesAsync();
    } // done

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
