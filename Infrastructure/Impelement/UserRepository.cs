using Application.Interface;
using Domain.Entity;
using Infrastructure.Context;

namespace Infrastructure.Impelement
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
