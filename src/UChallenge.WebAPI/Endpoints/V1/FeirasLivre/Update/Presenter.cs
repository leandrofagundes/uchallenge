using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Update;
using UChallenge.Framework.WebAPI.Endpoints;

namespace UChallenge.WebAPI.Endpoints.V1.FeirasLivre.Update
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

        public void InvalidEntityData(string message)
        {
            ViewModel = new BadRequestObjectResult(message);

            _logger.LogInformation("Bad Request: {message}", message);
        }

        public void InvalidInputData(Dictionary<string, string> errors)
        {
            ViewModel = new BadRequestObjectResult(errors);

            _logger.LogInformation("Bad Request: {errors}", string.Join(";", errors.Values));
        }

        public void NotFound(object value)
        {
            ViewModel = new NotFoundObjectResult(value);

            _logger.LogInformation("Not found: {value}", value);
        }

        public void Success(OutputData outputData)
        {
            var responseDTO = new ResponseDTO
            {
                Id = outputData.Id,
                Nome = outputData.Nome,
                Registro = outputData.Registro,
                Longitude = outputData.Longitude.ToDouble(),
                Latitude = outputData.Latitude.ToDouble(),
                CodigoDistrito = outputData.CodigoDistrito,
                NomeDistrito = outputData.NomeDistrito,
                AreaPonderacao = outputData.AreaPonderacao,
                SetorCensitario = outputData.SetorCensitario,
                Bairro = outputData.Bairro,
                CodigoSubPrefeitura = outputData.CodigoSubPrefeitura,
                NomeSubPrefeitura = outputData.NomeSubPrefeitura,
                Logradouro = outputData.Logradouro,
                Numero = outputData.Numero,
                Referencia = outputData.Referencia,
                RegiaoDivisaoEm5Areas = outputData.RegiaoDivisaoEm5Areas,
                RegiaoDivisaoEm8Areas = outputData.RegiaoDivisaoEm8Areas
            };

            ViewModel = new OkObjectResult(responseDTO)
            {
                StatusCode = StatusCodes.Status200OK
            };

            _logger.LogInformation("Success: {responseDTO}", responseDTO);
        }

        public void UnhandledException(Exception ex)
        {
            ViewModel = new StatusCodeResult(500);

            _logger.LogError(ex, "Unhandled Exception:");
        }
    }
}
