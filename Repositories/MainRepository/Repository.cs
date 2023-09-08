using System;
using OnlineMarket.Interfaces.IRepasitories.IMainRepository;

namespace OnlineMarket.Repositories.MainRepository
{
    public class Repository<T> : IRepository<T> where T : Auditable
    {
        protected readonly OnlineMarketDB dbContext;
        protected readonly DbSet<T> dbSet;

        public Repository(OnlineMarketDB dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var temp = (await dbSet.AddAsync(entity)).Entity;
            return temp;
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
            => dbSet.AsQueryable();

        public async Task<T> GetByIdAsync(long id)
            => await dbSet.FindAsync(id);

        public T Update(T entity)
            => dbSet.Update(entity).Entity;

        public async Task<int> SaveAsync()
           => await dbContext.SaveChangesAsync();
    }
}
