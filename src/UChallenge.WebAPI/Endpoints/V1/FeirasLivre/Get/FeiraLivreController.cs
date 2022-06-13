using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Get;
using UChallenge.Framework.WebAPI.Endpoints;

namespace UChallenge.WebAPI.Endpoints.V1.FeirasLivre.Get
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class FeiraLivreController :
        BaseController<Presenter>
    {

        public FeiraLivreController(
            IMediator mediator,
            Presenter presenter,
            ILogger<Presenter> logger) :
            base(mediator, presenter, logger)
        {
        }

        /// <summary>
        /// Requests to the server a list with all resources matching the parameters.
        /// If no parameters were passed, all the records will be fetched.
        /// If more then one parameter were passed, it will consider only the records matching both parameters.
        /// </summary>
        /// <param name="district">Name of the district where the Feira Livre is allocated.</param>
        /// <param name="name">Name of Feira Livre record</param>
        /// <param name="neighborhood">Name of the neighborhood where the Feira Livre is allocated.</param>
        /// <param name="region5">Name of the region when the division was made in 5 regions where the Feira Livre is allocated.</param>
        /// <param name="cancellationToken">A cancellation token for keep requests alive.</param>
        /// <response code="200">The data fetch executed with success.</response>
        /// <response code="204">The request was canceled by the client-side and no response will be sent.</response>
        /// <response code="500">The server encountered an error that could not handle. Please, contact our support for more info.</response>
        /// <returns><seealso cref="ResponseDTOItem">Response</seealso>Contains the created object data.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTOItem))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(
            [FromQuery] string district,
            [FromQuery] string region5,
            [FromQuery] string name,
            [FromQuery] string neighborhood,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("Request begins:", new { district, region5, name, neighborhood });

            var inputData = new InputData(name, district, region5, neighborhood);

            await _mediator.PublishAsync(inputData, cancellationToken);

            return _presenter.ViewModel;
        }
    }
}
