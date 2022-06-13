using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public FeiraLivreController(
            IMediator mediator,
            Presenter presenter,
            ILogger<Presenter> logger) : base(mediator, presenter, logger)
        {

        }

        /// <summary>
        /// Requests to server creation of a record for Feira Livre.
        /// </summary>
        /// <param name="requestDTO">Feira Livre data to create the record</param>
        /// <response code="201">The record was created successfully</response>
        /// <response code="400">The record was not created because of a bad request. Check if the input data follow the definitions and try again.</response>
        /// <response code="409">The record was not created because of conflict. Check if the id value is unique and try again.</response>
        /// <response code="500">The server encountered an error that could not handle. Please, contact our support for more info.</response>
        /// <returns><seealso cref="ResponseDTO">Response</seealso>Contains the created object data.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] RequestDTO requestDTO)
        {
            _logger.LogInformation("Request begins:", requestDTO);

            var inputData = new InputData(
                requestDTO.Id,
                requestDTO.Nome,
                requestDTO.Registro,
                requestDTO.Longitude,
                requestDTO.Latitude,
                requestDTO.SetorCensitario,
                requestDTO.AreaPonderacao,
                requestDTO.CodigoDistrito,
                requestDTO.NomeDistrito,
                requestDTO.CodigoSubPrefeitura,
                requestDTO.NomeSubPrefeitura,
                requestDTO.RegiaoDivisaoEm5Areas,
                requestDTO.RegiaoDivisaoEm8Areas,
                requestDTO.Logradouro,
                requestDTO.Numero,
                requestDTO.Bairro,
                requestDTO.Referencia);

            await _mediator.PublishAsync(inputData);

            return _presenter.ViewModel;
        }
    }
}
