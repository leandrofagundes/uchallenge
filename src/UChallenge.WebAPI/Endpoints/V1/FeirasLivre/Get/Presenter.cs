using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Get;
using UChallenge.Framework.WebAPI.Endpoints;

namespace UChallenge.WebAPI.Endpoints.V1.FeirasLivre.Get
{
    public sealed class Presenter :
        BasePresenter,
        IOutputPort
    {
        public void OperationCancelled()
        {
            ViewModel = new NoContentResult();
        }

        public void Success(OutputData outputData)
        {
            var items = outputData.Items.Select(item => new ResponseDTOItem
            {
                Id = item.Id,
                Nome = item.Nome,
                Registro = item.Registro,
                Longitude = item.Longitude.ToDouble(),
                Latitude = item.Latitude.ToDouble(),
                AreaPonderacao = item.AreaPonderacao,
                SetorCensitario = item.SetorCensitario,
                CodigoDistrito = item.CodigoDistrito,
                NomeDistrito = item.NomeDistrito,
                CodigoSubPrefeitura = item.CodigoSubPrefeitura,
                NomeSubPrefeitura = item.NomeSubPrefeitura,
                RegiaoDivisaoEm5Areas = item.RegiaoDivisaoEm5Areas,
                RegiaoDivisaoEm8Areas = item.RegiaoDivisaoEm8Areas,
                Logradouro = item.Logradouro,
                Numero = item.Numero,
                Bairro = item.Bairro,
                Referencia = item.Referencia
            });

            var responseDTO = new ResponseDTO
            {
                Items = items
            };

            ViewModel = new OkObjectResult(responseDTO)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
