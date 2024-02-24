using Application.Interface;
using Application.Services;
using Infrastructure.Context;
using Infrastructure.Impelement;
using Microsoft.EntityFrameworkCore;


namespace MyProject
{
    public static class ConfigureService
    {
        public static IServiceCollection AddWebServiceCollection(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(optinos =>
            {
                optinos.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            return builder.Services;
        }
    }
}
