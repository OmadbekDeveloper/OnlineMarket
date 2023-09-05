// DONE
using OnlineMarket.Models.Dtos.CartItem;

namespace OnlineMarket.Interfaces.Models
{
    public interface ICartItemService
    {
        Task<List<CartItem>> GetCartItemsByCartIdAsync();
        Task<CartItem> GetCartItemByIdAsync(int id);
        Task AddCartItemAsync(CreateCartItemDto cartItemdto);
        Task<bool> UpdateCartItemAsync(int id, CartItem updatedCartItem);
        Task<bool> RemoveCartItemAsync(int id);
    }
}
