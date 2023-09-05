using OnlineMarket.Models.Dtos.ShippingInfo;

namespace OnlineMarket.Interfaces.Models
{
    public interface IShippingInfoService
    {
        Task<List<ShippingInfo>> GetShippingInfoByOrderAsync();
        Task<ShippingInfo> GetShippingInfoByOrderIdAsync(int orderId);
        Task CreateShippingInfoAsync(CreateShippingInfoDto createShippingInfoDto);
        Task<bool> UpdateShippingInfoAsync(int orderId, ShippingInfo updatedShippingInfo);
        // Add more methods as needed
    }
}
