using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UChallenge.Domain.FeiraLivreAggregates;
using UChallenge.Framework.Domain.Repositories;
using UChallenge.MSSQL.FeiraLivreAggregates;

namespace UChallenge.MSSQL.Extensions.IServiceCollectionExtensions
{
    public static class MSSqlServerDbExtensions
    {
        public static void AddMSSqlServerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MSSqlServerDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("UChallenge")));

            services.AddScoped<MSSqlServerDbContext, MSSqlServerDbContext>();
            services.AddScoped<IUnitOfWork, MSSqlServerUnitOfWork>();
            services.AddScoped<IFeiraLivreRepository, FeiraLivreRepository>();
            services.AddScoped<IFeiraLivreFactory, FeiraLivreFactory>();
        }
    }
}
