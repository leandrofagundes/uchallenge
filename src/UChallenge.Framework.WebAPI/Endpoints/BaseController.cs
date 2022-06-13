using FluentMediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UChallenge.Framework.WebAPI.Endpoints
{
    public abstract class BaseController<TPresenter> :
        Controller
        where TPresenter : IPresenter
    {
        protected readonly IMediator _mediator;
        protected readonly TPresenter _presenter;
        protected readonly ILogger<TPresenter> _logger;

        protected BaseController(
           IMediator mediator,
           TPresenter presenter,
           ILogger<TPresenter> logger)
        {
            _mediator = mediator;
            _presenter = presenter;
            _logger = logger;
        }
    }
}
