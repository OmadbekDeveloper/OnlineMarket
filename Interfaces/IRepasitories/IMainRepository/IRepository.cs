
using System.Security.AccessControl;

namespace OnlineMarket.Interfaces.IRepasitories.IMainRepository
{
    public interface IRepository<T> where T : Auditable
    {
        Task<T> CreateAsync(T entity);
        T Update(T entity);
        Task<T> GetByIdAsync(long id);
        void Delete(T entity);
        IQueryable<T> GetAll();
        Task<int> SaveAsync();
    }
}
