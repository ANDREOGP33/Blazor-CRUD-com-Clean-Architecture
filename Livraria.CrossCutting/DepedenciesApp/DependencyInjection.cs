using Livraria.Domain.Abstractions;
using Livraria.Infrastructure.Context;
using Livraria.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Livraria.CrossCutting.DepedenciesApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration
                                  .GetConnectionString("sqlite");

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite(connectionString));

            services.AddScoped<ILivroRepository, LivroRepository>();
            //service.AddScoped<IlivroService, LivroService>();

            return services;
        }
    }
}
