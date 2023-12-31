﻿using OnlineMarket.Interfaces.Repasitories.Generic;

namespace OnlineMarket.Interfaces.Repasitories.Services
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable<Product> GetByNameAsync(string Name);
        

    }
}
