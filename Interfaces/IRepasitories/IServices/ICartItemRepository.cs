using OnlineMarket.Interfaces.Repasitories.Generic;

namespace OnlineMarket.Interfaces.Repasitories.Services
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<CartItem> GetByIdAsync(int id);
    }


}
