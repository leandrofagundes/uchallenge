using Microsoft.Extensions.DependencyInjection;

namespace UChallenge.WebAPI.Extensions.IServiceCollectionExtensions
{
    internal static class V1PresentersExtension
    {
        public static void AddV1Presenters(this IServiceCollection services)
        {
            AddV1FeirasLivrePresenters(ref services);
        }

        private static void AddV1FeirasLivrePresenters(ref IServiceCollection services)
        {
            services.AddScoped<Endpoints.V1.FeirasLivre.Create.Presenter, Endpoints.V1.FeirasLivre.Create.Presenter>();
            services.AddScoped<Application.UseCases.V1.FeiraLivreUseCases.Create.IOutputPort>(x => x.GetRequiredService<Endpoints.V1.FeirasLivre.Create.Presenter>());

            services.AddScoped<Endpoints.V1.FeirasLivre.Update.Presenter, Endpoints.V1.FeirasLivre.Update.Presenter>();
            services.AddScoped<Application.UseCases.V1.FeiraLivreUseCases.Update.IOutputPort>(x => x.GetRequiredService<Endpoints.V1.FeirasLivre.Update.Presenter>());

            services.AddScoped<Endpoints.V1.FeirasLivre.Delete.Presenter, Endpoints.V1.FeirasLivre.Delete.Presenter>();
            services.AddScoped<Application.UseCases.V1.FeiraLivreUseCases.Delete.IOutputPort>(x => x.GetRequiredService<Endpoints.V1.FeirasLivre.Delete.Presenter>());

            services.AddScoped<Endpoints.V1.FeirasLivre.Get.Presenter, Endpoints.V1.FeirasLivre.Get.Presenter>();
            services.AddScoped<Application.UseCases.V1.FeiraLivreUseCases.Get.IOutputPort>(x => x.GetRequiredService<Endpoints.V1.FeirasLivre.Get.Presenter>());
        }
    }
}
