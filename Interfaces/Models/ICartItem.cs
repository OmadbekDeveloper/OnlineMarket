// DONE
using OnlineMarket.Models.Dtos.CartItem;

namespace OnlineMarket.Interfaces.Models
{
    public interface ICartItemService
    {
        Task<Responce<IEnumerable<ResultCartItemDto>>> GetCartItemAllAsync();
        Task<Responce<ResultCartItemDto>> GetCartItemByIdAsync(int id);
        Task<Responce<ResultCartItemDto>> AddCartItemAsync(CreateCartItemDto cartItemdto);
        Task<Responce<ResultCartItemDto>> UpdateCartItemAsync(UpdateCartItemDto updateCartItemDto);
        Task<Responce<bool>> RemoveCartItemAsync(int id);
    }
}
