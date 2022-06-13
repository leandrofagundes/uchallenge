using Microsoft.Extensions.DependencyInjection;

namespace UChallenge.WebAPI.Extensions.IServiceCollectionExtensions
{
    internal static class V1UseCasesExtensions
    {
        public static void AddV1UseCases(this IServiceCollection services)
        {
            AddV1FeirasLivreUseCases(ref services);
        }

        private static void AddV1FeirasLivreUseCases(ref IServiceCollection services)
        {
            services.AddScoped<Application.UseCases.V1.FeiraLivreUseCases.Create.IUseCase, Application.UseCases.V1.FeiraLivreUseCases.Create.UseCase>();
            services.AddScoped<Application.UseCases.V1.FeiraLivreUseCases.Update.IUseCase, Application.UseCases.V1.FeiraLivreUseCases.Update.UseCase>();
        }
    }
}
