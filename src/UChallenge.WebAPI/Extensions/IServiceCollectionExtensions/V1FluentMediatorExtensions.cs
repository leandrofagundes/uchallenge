using FluentMediator;
using Microsoft.Extensions.DependencyInjection;

namespace UChallenge.WebAPI.Extensions.IServiceCollectionExtensions
{
    internal static class V1FluentMediatorExtensions
    {
        public static void AddV1Mediators(this IServiceCollection services)
        {
            var builder = new PipelineProviderBuilder();

            AddV1FeirasLivreMediators(ref builder);

            var pipelineProvider = builder.Build();

            services.AddTransient<GetService>(c => c.GetService);
            services.AddTransient(c => pipelineProvider);
            services.AddTransient<IMediator, Mediator>();
        }

        private static void AddV1FeirasLivreMediators(ref PipelineProviderBuilder builder)
        {
            builder.On<Application.UseCases.V1.FeiraLivreUseCases.Create.InputData>().PipelineAsync()
               .Call<Application.UseCases.V1.FeiraLivreUseCases.Create.IUseCase>((handler, request) => handler.RequestAsync(request));

            builder.On<Application.UseCases.V1.FeiraLivreUseCases.Update.InputData>().PipelineAsync()
               .Call<Application.UseCases.V1.FeiraLivreUseCases.Update.IUseCase>((handler, request) => handler.RequestAsync(request));

            builder.On<Application.UseCases.V1.FeiraLivreUseCases.Delete.InputData>().PipelineAsync()
               .Call<Application.UseCases.V1.FeiraLivreUseCases.Delete.IUseCase>((handler, request) => handler.RequestAsync(request));
        }
    }
}
