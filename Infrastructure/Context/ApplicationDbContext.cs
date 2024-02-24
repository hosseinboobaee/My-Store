using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
                
        }

        #region Db Sets

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDelete == true);
            //modelBuilder.Entity<ProductBrand>().HasQueryFilter(x => x.IsDelete == true);
            //modelBuilder.Entity<ProductType>().HasQueryFilter(x => x.IsDelete == true);
        }
    }
  
}
