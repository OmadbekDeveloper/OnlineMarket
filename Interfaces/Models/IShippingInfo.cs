namespace OnlineMarket.Interfaces.Models
{
    public interface IShippingInfoService
    {
        Task<ShippingInfo> GetShippingInfoByOrderIdAsync(int orderId);
        Task<ShippingInfo> CreateShippingInfoAsync(ShippingInfo shippingInfo);
        Task<bool> UpdateShippingInfoAsync(int orderId, ShippingInfo updatedShippingInfo);
        // Add more methods as needed
    }
}
