

public class ShippingInfoService : IShippingInfoService
{
    private readonly OnlineMarketDB _context;

    public ShippingInfoService(OnlineMarketDB context)
    {
        _context = context;
    }
    public async Task<List<ShippingInfo>> GetShippingInfoByOrderAsync()
    {
        return await _context.ShippingInfos.ToListAsync();
    } // done

    public async Task<ShippingInfo> GetShippingInfoByOrderIdAsync(int orderId)
    {
        return await _context.ShippingInfos.FindAsync(orderId);
    } // done

    public async Task<ShippingInfo> CreateShippingInfoAsync(ShippingInfo shippingInfo)
    {
        await _context.ShippingInfos.AddAsync(shippingInfo);
        await _context.SaveChangesAsync();
        return shippingInfo;
    }

    public async Task<bool> UpdateShippingInfoAsync(int orderId, ShippingInfo updatedShippingInfo)
    {
        var shippingInfo = await _context.ShippingInfos
            .FirstOrDefaultAsync(si => si.OrderId == orderId);

        if (shippingInfo == null)
            return false;

        _context.Entry(shippingInfo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }
}
