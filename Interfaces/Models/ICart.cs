// DONE

using OnlineMarket.Models.Dtos.Cart;

namespace OnlineMarket.Interfaces.Models
{
    public interface ICartService
    {
        Task<List<Cart>> GetAllCartsAsync();
        Task<Cart> GetCartByIdAsync(int id);
        Task CreateCartAsync(UniversalCartDto cartdto);
        Task<bool> UpdateCartAsync(int id, Cart updatedCart);
        Task<bool> DeleteCartAsync(int id);
        Task<decimal> CalculateCartTotalAsync(int id);
    }
}
