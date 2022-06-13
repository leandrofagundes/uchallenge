using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Delete;
using UChallenge.Framework.WebAPI.Endpoints;

namespace UChallenge.WebAPI.Endpoints.V1.FeirasLivre.Delete
{
    public sealed class Presenter :
        IPresenter,
        IOutputPort
    {
        private readonly ILogger<Presenter> _logger;
        public IActionResult ViewModel { get; private set; }

        public Presenter(ILogger<Presenter> logger)
        {
            _logger = logger;
        }

        public void NotFound(object value)
        {
            ViewModel = new NotFoundObjectResult(value);

            _logger.LogInformation("NotFound: {value}", value);
        }

        public void Success()
        {
            ViewModel = new NoContentResult();

            _logger.LogInformation("Success");
        }

        public void UnhandledException(Exception ex)
        {
            ViewModel = new StatusCodeResult(500);

            _logger.LogError(ex, "Unhandled Exception:");
        }
    }
}
