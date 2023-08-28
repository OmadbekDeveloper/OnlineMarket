// DONE
namespace OnlineMarket.Interfaces.Models
{
    public interface ICartService
    {
        Task<List<Cart>> GetAllCartsAsync();
        Task<Cart> GetCartByIdAsync(int id);
        Task<Cart> CreateCartAsync(int cartid);
        Task<bool> UpdateCartAsync(int id, Cart updatedCart);
        Task<bool> DeleteCartAsync(int id);
        Task<decimal> CalculateCartTotalAsync(int id);
    }
}
