using Microsoft.AspNetCore.Mvc;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Delete;
using UChallenge.Framework.WebAPI.Endpoints;

namespace UChallenge.WebAPI.Endpoints.V1.FeirasLivre.Delete
{
    public sealed class Presenter :
        BasePresenter,
        IOutputPort
    {
        public void NotFound(object value)
        {
            ViewModel = new NotFoundObjectResult(value);
        }

        public void Success()
        {
            ViewModel = new NoContentResult();
        }
    }
}
