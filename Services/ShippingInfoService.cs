using OnlineMarket.Models.Dtos.ShippingInfo;

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

    public async Task CreateShippingInfoAsync(CreateShippingInfoDto createShippingInfoDto)
    {
        var shippinginfocreate = new ShippingInfo()
        {
            ShippingInfoId = createShippingInfoDto.ShippingInfoId,
            OrderId = createShippingInfoDto.OrderId,
            Address = createShippingInfoDto.Address,
            City = createShippingInfoDto.City,
            PostalCode = createShippingInfoDto.PostalCode,
            Country = createShippingInfoDto.Country,
        };

        await _context.ShippingInfos.AddAsync(shippinginfocreate);
        await _context.SaveChangesAsync();
    } // orderid not

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
