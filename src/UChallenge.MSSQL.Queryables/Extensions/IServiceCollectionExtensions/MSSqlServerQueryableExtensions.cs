using Microsoft.Extensions.DependencyInjection;
using UChallenge.Domain.FeiraLivreAggregates.Queryables;

namespace UChallenge.MSSQL.Queryables.Extensions.IServiceCollectionExtensions
{
    public static class MSSqlServerQueryableExtensions
    {
        public static void AddMSSqlServerQueryServices(this IServiceCollection services)
        {
            services.AddScoped<IFeiraLivreQueryable, FeiraLivreQueryable>();
        }
    }
}
