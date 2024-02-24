using Application.Interface;
using Infrastructure.Context;

namespace Infrastructure.Impelement
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IProductRepository Products { get; }
        public IUserRepository Users { get; }
        public UnitOfWork(ApplicationDbContext dbContext,
                            IProductRepository productRepository,
                            IUserRepository userRepository)
        {
            _dbContext = dbContext;
            Products = productRepository;
            Users = userRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
