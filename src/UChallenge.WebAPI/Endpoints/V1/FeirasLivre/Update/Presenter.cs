﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Update;
using UChallenge.Framework.WebAPI.Endpoints;

namespace UChallenge.WebAPI.Endpoints.V1.FeirasLivre.Update
{
    public sealed class Presenter :
        BasePresenter,
        IOutputPort
    {
        public void InvalidEntityData(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }

        public void InvalidInputData(Dictionary<string, string> errors)
        {
            ViewModel = new BadRequestObjectResult(errors);
        }

        public void NotFound(object value)
        {
            ViewModel = new NotFoundObjectResult(value);
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
        }
    }
}