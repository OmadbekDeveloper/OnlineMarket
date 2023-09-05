
namespace OnlineMarket.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; set; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
