﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Create;
using UChallenge.Framework.WebAPI.Endpoints;

namespace UChallenge.WebAPI.Endpoints.V1.FeirasLivre.Create
{
    public sealed class Presenter :
        BasePresenter,
        IOutputPort
    {
        public void DuplicatedData(string message, object value)
        {
            ViewModel = new ConflictObjectResult(message);
        }

        public void InvalidEntityData(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }

        public void InvalidInputData(Dictionary<string, string> errors)
        {
            ViewModel = new BadRequestObjectResult(errors);
        }

        public void Success(OutputData outputData)
        {
            var responseDTO = new ResponseDTO
            {
                Id = outputData.Id,
                NomeFeira = outputData.NomeFeira,
                RegistroFeira = outputData.RegistroFeira,
                Longitude = outputData.Longitude.ToDouble(),
                Latitude = outputData.Latitude.ToDouble(),
                CodigoDistrito = outputData.CodigoDistrito,
                NomeDistrito = outputData.NomeDistrito,
                AreaDePonderacao = outputData.AreaDePonderacao,
                SetorCensitario = outputData.SetorCensitario,
                Bairro = outputData.Bairro,
                CodigoSubPrefeitura = outputData.CodigoSubPrefeitura,
                NomeSubPrefeitura = outputData.NomeSubPrefeitura,
                Logradouro = outputData.Logradouro,
                Numero = outputData.Numero,
                Referencia = outputData.Referencia,
                RegiaoPorDivisaoEm5Areas = outputData.RegiaoPorDivisaoEm5Areas,
                RegiaoPorDivisaoEm8Areas = outputData.RegiaoPorDivisaoEm8Areas
            };

            ViewModel = new OkObjectResult(responseDTO)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}