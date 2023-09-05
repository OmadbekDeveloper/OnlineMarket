
using Microsoft.EntityFrameworkCore;

namespace OnlineMarket.Repasitories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(OnlineMarketDB dbContext) : base(dbContext)
        {

        }
    }
}
