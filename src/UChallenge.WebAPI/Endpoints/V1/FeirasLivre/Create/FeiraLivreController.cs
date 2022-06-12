using FluentMediator;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Create;
using UChallenge.Framework.WebAPI.Endpoints;

namespace UChallenge.WebAPI.Endpoints.V1.FeirasLivre.Create
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FeiraLivreController :
        BaseController<Presenter>
    {

        public FeiraLivreController(IMediator mediator, Presenter presenter) :
            base(mediator, presenter)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestDTO requestDTO)
        {
            var inputData = new InputData(
                requestDTO.Id,
                 requestDTO.NomeFeira,
                 requestDTO.RegistroFeira,
                 requestDTO.Longitude,
                 requestDTO.Latitude,
                 requestDTO.SetorCensitario,
                 requestDTO.AreaDePonderacao,
                 requestDTO.CodigoDistrito,
                 requestDTO.NomeDistrito,
                 requestDTO.CodigoSubPrefeitura,
                 requestDTO.NomeSubPrefeitura,
                 requestDTO.RegiaoPorDivisaoEm5Areas,
                 requestDTO.RegiaoPorDivisaoEm8Areas,
                 requestDTO.Logradouro,
                 requestDTO.Numero,
                 requestDTO.Bairro,
                 requestDTO.Referencia);

            await _mediator.PublishAsync(inputData);

            return _presenter.ViewModel;
        }
    }
}
