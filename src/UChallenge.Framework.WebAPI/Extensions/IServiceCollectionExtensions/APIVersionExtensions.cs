using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace UChallenge.Framework.WebAPI.Extensions.IServiceCollectionExtensions
{
    public static class APIVersionExtensions
    {
        public static void AddAPIVersionCustomized(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'V";
                p.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
