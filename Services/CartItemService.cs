
public class CartItemService : ICartItemService
{
    private readonly OnlineMarketDB _context;

    public CartItemService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<CartItem>> GetCartItemsByCartIdAsync()
    {
        return await _context.CartItems.ToListAsync();
    } // done

    public async Task<CartItem> GetCartItemByIdAsync(int id)
    {
        return await _context.CartItems.FindAsync(id);
    } // done

    public async Task AddCartItemAsync(CreateCartItemDto cartItemdto)
    {
        var cartitemrcreate = new CartItem()
        {
            CartItemId = cartItemdto.CartItemId,
            CartId = cartItemdto.CartId,
            ProductId = cartItemdto.ProductId,
            Quantity = cartItemdto.Quantity,
        };

        await _context.CartItems.AddAsync(cartitemrcreate);
        await _context.SaveChangesAsync();
    } // done

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
