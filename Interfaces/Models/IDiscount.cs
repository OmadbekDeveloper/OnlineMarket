namespace OnlineMarket.Interfaces.Models
{
    public interface IDiscountService
    {
        Task<List<Discount>> GetAllDiscountsAsync();
        Task<Discount> GetDiscountByIdAsync(int id);
        Task<Discount> CreateDiscountAsync(Discount discount);
        Task<bool> UpdateDiscountAsync(int id, Discount updatedDiscount);
        Task<bool> DeleteDiscountAsync(int id);
    }
}
