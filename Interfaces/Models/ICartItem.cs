// DONE
namespace OnlineMarket.Interfaces.Models
{
    public interface ICartItemService
    {
        Task<List<CartItem>> GetCartItemsByCartIdAsync();
        Task<CartItem> GetCartItemByIdAsync(int id);
        Task<CartItem> AddCartItemAsync(CartItem cartItem);
        Task<bool> UpdateCartItemAsync(int id, CartItem updatedCartItem);
        Task<bool> RemoveCartItemAsync(int id);
    }
}
