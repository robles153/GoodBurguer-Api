using GoodBurguer.GoodBurguer.Application.Interfaces;
using GoodBurguer.GoodBurguer.Infrastructure.Data.Context;
using GoodBurguer.GoodBurguer.Infrastructure.Data.Repositories;
using GoodBurguer.GoodBurguer.Infrastructure.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace GoodBurguer.GoodBurguer.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
