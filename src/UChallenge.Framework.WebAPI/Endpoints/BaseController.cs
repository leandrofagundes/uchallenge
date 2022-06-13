using FluentMediator;
using Microsoft.AspNetCore.Mvc;

namespace UChallenge.Framework.WebAPI.Endpoints
{
    public abstract class BaseController<TPresenter> :
        Controller
        where TPresenter : BasePresenter
    {
        protected readonly IMediator _mediator;
        protected readonly TPresenter _presenter;

        protected BaseController(
           IMediator mediator,
           TPresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }
    }
}
