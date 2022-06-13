using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Update;
using UChallenge.Framework.WebAPI.Endpoints;

namespace UChallenge.WebAPI.Endpoints.V1.FeirasLivre.Update
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/{id}")]
    [ApiController]
    public class FeiraLivreController :
        BaseController<Presenter>
    {

        public FeiraLivreController(IMediator mediator, Presenter presenter) :
            base(mediator, presenter)
        {

        }

        /// <summary>
        /// Requests to the server update a record for Feira Livre.
        /// </summary>
        /// <param name="id">Identification number of the establishment which will be updated.</param>
        /// <param name="requestDTO">Feira Livre data to update</param>
        /// <response code="200">The record was updated successfully</response>
        /// <response code="400">The record was not created because of a bad request. Check if the input data follow the definitions and try again.</response>
        /// <response code="404">The record was not updated because it was not found. Check if the id value is from a valid resource and try again.</response>
        /// <response code="500">The server encountered an error that could not handle. Please, contact our support for more info.</response>
        /// <returns><seealso cref="ResponseDTO">Response</seealso>Contains the created object data.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] RequestDTO requestDTO)
        {
            var inputData = new InputData(
                id,
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
