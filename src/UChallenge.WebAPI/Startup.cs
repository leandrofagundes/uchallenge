using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UChallenge.MSSQL;
using UChallenge.MSSQL.Extensions.IServiceCollectionExtensions;
using UChallenge.MSSQL.Queryables.Extensions.IServiceCollectionExtensions;
using UChallenge.WebAPI.Extensions.IServiceCollectionExtensions;

namespace UChallenge.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddVersionedApiExplorer();
            services.AddControllers();
            services.AddSwagger();
            services.AddMSSqlServerServices(Configuration);
            services.AddMSSqlServerQueryServices();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureDevelopment(IApplicationBuilder app, MSSqlServerDbContext dbContext)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "UChallenge WebAPI v1"));

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            dbContext.Database.Migrate();
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddVersionedApiExplorer();
            services.AddControllers();
            services.AddMSSqlServerServices(Configuration);
            services.AddMSSqlServerQueryServices();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureProduction(IApplicationBuilder app, MSSqlServerDbContext dbContext)
        {
            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            dbContext.Database.Migrate();
        }
    }
}
