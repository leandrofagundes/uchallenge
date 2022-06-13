using Microsoft.AspNetCore.Mvc;

namespace UChallenge.Framework.WebAPI.Endpoints
{
    public interface IPresenter
    {
        IActionResult ViewModel { get; }
    }
}
