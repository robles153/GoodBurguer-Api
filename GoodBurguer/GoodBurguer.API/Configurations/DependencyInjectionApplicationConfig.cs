using System.Reflection;
using GoodBurguer.GoodBurguer.Domain.Strategies;

namespace GoodBurguer.GoodBurguer.API.Configurations
{
    public static class DependencyInjectionApplicationConfig
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Strategies 
            services.AddScoped<IDescontoStrategy, DescontoComboCompleto>();
            services.AddScoped<IDescontoStrategy, DescontoSanduicheBebida>();
            services.AddScoped<IDescontoStrategy, DescontoSanduicheAcompanhamento>();
            services.AddScoped<IDescontoStrategy, SemDescontoStrategy>();

            return services;
        }
    }
}
