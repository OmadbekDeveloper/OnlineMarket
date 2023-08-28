// DONE

using Microsoft.EntityFrameworkCore;

public class DiscountService : IDiscountService
{
    private readonly OnlineMarketDB _context;

    public DiscountService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<List<Discount>> GetAllDiscountsAsync()
    {
        return await _context.Discounts.ToListAsync();
    }

    public async Task<Discount> GetDiscountByIdAsync(int id)
    {
        return await _context.Discounts.FindAsync(id);
    }

    public async Task<Discount> CreateDiscountAsync(Discount discount)
    {
        var existingDiscount = await _context.Discounts.FirstOrDefaultAsync(d => d.Code == discount.Code);

        if (existingDiscount != null)
        {
            throw new Exception("Discount with the same code already exists.");
        }

        _context.Discounts.Add(discount);
        await _context.SaveChangesAsync();

        return discount;
    }

    public async Task<bool> UpdateDiscountAsync(int id, Discount updatedDiscount)
    {
        var existingDiscount = await _context.Discounts.FindAsync(id);

        if (existingDiscount == null)
        {
            throw new Exception("Discount not found.");
            return false;
        }

        existingDiscount.Code = updatedDiscount.Code;
        existingDiscount.Type = updatedDiscount.Type;
        existingDiscount.Value = updatedDiscount.Value;
        existingDiscount.ExpiryDate = updatedDiscount.ExpiryDate;

        _context.Discounts.Update(existingDiscount);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteDiscountAsync(int id)
    {
        var discount = await _context.Discounts.FindAsync(id);

        if (discount == null)
        {
            throw new Exception("Discount not found.");
            return false;
        }

        _context.Discounts.Remove(discount);
        await _context.SaveChangesAsync();
        return true;
    }
}
