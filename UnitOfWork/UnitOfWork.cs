namespace OnlineMarket.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineMarketDB _dbContext;
        private IProductRepository _productRepository;


        public UnitOfWork(OnlineMarketDB dbContext)
        {
            _dbContext = dbContext;
        }


        public IProductRepository ProductRepository
        {
            get { return _productRepository = _productRepository ?? new ProductRepository(_dbContext); }
        }


        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
