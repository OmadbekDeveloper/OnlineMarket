


using Microsoft.EntityFrameworkCore;
using System;

namespace OnlineMarket.Repositories.Service
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(OnlineMarketDB dbContext) : base(dbContext)
        {
            
        }

        public IQueryable<Product> GetByNameAsync(string Name)
                => _dbContext.Products.Where(p => p.Name.Contains(Name)).AsQueryable();

    }
}
