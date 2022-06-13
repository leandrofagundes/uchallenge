using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Delete;
using UChallenge.Framework.WebAPI.Endpoints;

namespace UChallenge.WebAPI.Endpoints.V1.FeirasLivre.Delete
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
        /// Requests to the server delete a Feira Livre record.
        /// </summary>
        /// <param name="id">Identification number of the establishment which will be updated.</param>
        /// <response code="204">The record was deleted successfully</response>
        /// <response code="404">The record was not deleted because it was not found. Check if the id value is from a valid resource and try again.</response>
        /// <response code="500">The server encountered an error that could not handle. Please, contact our support for more info.</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromRoute] int id)
        {
            var inputData = new InputData(id);

            await _mediator.PublishAsync(inputData);

            return _presenter.ViewModel;
        }
    }
}
