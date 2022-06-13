using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace UChallenge.WebAPI.Extensions.IServiceCollectionExtensions
{
    internal static class V1SwaggerGenerator
    {
        internal static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "UChallenger API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Leandro Fagundes",
                        Email = "leandro@fagundes.email"
                    },
                    Description = "Documentation for UChallenge V1 API",
                });

                options.CustomSchemaIds(schema => schema.FullName);

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml"), true);
            });
        }
    }
}
