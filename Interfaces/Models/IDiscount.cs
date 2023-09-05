using OnlineMarket.Models.Dtos.Discount;

namespace OnlineMarket.Interfaces.Models
{
    public interface IDiscountService
    {
        Task<List<Discount>> GetAllDiscountsAsync();
        Task<Discount> GetDiscountByIdAsync(int id);
        Task CreateDiscountAsync(CreateDiscountDto discountdto);
        Task<bool> UpdateDiscountAsync(int id, Discount updatedDiscount);
        Task<bool> DeleteDiscountAsync(int id);
    }
}
