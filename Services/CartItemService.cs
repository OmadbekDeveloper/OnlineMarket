// DONE
public class CartItemService : ICartItemService
{
    private readonly OnlineMarketDB _context;

    public CartItemService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<CartItem>> GetCartItemsByCartIdAsync()
    {
        return await _context.CartItems
            .Include(item => item.Product)
            .ToListAsync();
    }

    public async Task<CartItem> GetCartItemByIdAsync(int id)
    {
        return await _context.CartItems
            .Include(item => item.Product)
            .FirstOrDefaultAsync(item => item.CartItemId == id);
    }

    public async Task<CartItem> AddCartItemAsync(CartItem cartItem)
    {
        await _context.CartItems.AddAsync(cartItem);
        await _context.SaveChangesAsync();
        return cartItem;
    }

    public async Task<bool> UpdateCartItemAsync(int id, CartItem updatedCartItem)
    {
        var cartItem = await _context.CartItems.FindAsync(id);

        if (cartItem == null)
        {
            throw new Exception("Cart item not found.");
            return false;
        }

        cartItem.Quantity = cartItem.Quantity;

        _context.CartItems.Update(cartItem);
        await _context.SaveChangesAsync();
        return true;
    }


    public async Task<bool> RemoveCartItemAsync(int id)
    {
        var cartItem = await _context.CartItems.FindAsync(id);

        if (cartItem == null)
        {
            throw new Exception("Cart item not found.");
            return false;
        }

        _context.CartItems.Remove(cartItem);
        await _context.SaveChangesAsync();
        return true;
    }
}
