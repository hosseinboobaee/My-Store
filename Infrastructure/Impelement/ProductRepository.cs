using Application.Interface;
using Domain.Entity;
using Infrastructure.Context;

namespace Infrastructure.Impelement
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
