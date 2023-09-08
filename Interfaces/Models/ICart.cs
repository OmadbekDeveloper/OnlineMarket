// DONE

using OnlineMarket.Models.Dtos.Cart;

namespace OnlineMarket.Interfaces.Models
{
    public interface ICartService
    {
        Task<Responce<IEnumerable<UniversalCartDto>>> GetAllCartsAsync();
        Task<Responce<UniversalCartDto>> GetCartByIdAsync(int id);
        Task<Responce<UniversalCartDto>> CreateCartAsync(UniversalCartDto cartdto);
        Task<Responce<bool>> DeleteCartAsync(int id);
    }
}
