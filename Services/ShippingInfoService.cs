

public class ShippingInfoService : IShippingInfoService
{
    private readonly OnlineMarketDB _context;

    public ShippingInfoService(OnlineMarketDB context)
    {
        _context = context;
    }

    public async Task<ShippingInfo> GetShippingInfoByOrderIdAsync(int orderId)
    {
        return await _context.ShippingInfo
            .FirstOrDefaultAsync(si => si.OrderId == orderId);
    }

    public async Task<ShippingInfo> CreateShippingInfoAsync(ShippingInfo shippingInfo)
    {
        _context.ShippingInfo.Add(shippingInfo);
        await _context.SaveChangesAsync();
        return shippingInfo;
    }

    public async Task<bool> UpdateShippingInfoAsync(int orderId, ShippingInfo updatedShippingInfo)
    {
        var shippingInfo = await _context.ShippingInfo
            .FirstOrDefaultAsync(si => si.OrderId == orderId);

        if (shippingInfo == null)
            return false;

        _context.Entry(shippingInfo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }
}
