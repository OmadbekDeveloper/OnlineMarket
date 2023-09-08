using OnlineMarket.Interfaces.Repasitories.Generic;

namespace OnlineMarket.Interfaces.Repasitories.Services
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart> GetByIdAsync(int id);
    }
}
