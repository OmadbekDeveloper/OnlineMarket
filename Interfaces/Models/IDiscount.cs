using OnlineMarket.Models.Dtos.Discount;

namespace OnlineMarket.Interfaces.Models
{
    public interface IDiscountService
    {
        Task<Responce<IEnumerable<ResultDiscountDto>>> GetAllDiscountsAsync();
        Task<Responce<ResultDiscountDto>> GetDiscountByIdAsync(int id);
        Task<Responce<ResultDiscountDto>> CreateDiscountAsync(CreateDiscountDto discountdto);
        Task<Responce<IEnumerable<ResultDiscountDto>>> UpdateDiscountAsync(UpdateDiscountDto updatedto);
        Task<Responce<bool>> DeleteDiscountAsync(int id);
    }
}
