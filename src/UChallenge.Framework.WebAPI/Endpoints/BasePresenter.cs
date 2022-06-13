using Microsoft.AspNetCore.Mvc;
using System;

namespace UChallenge.Framework.WebAPI.Endpoints
{
    public abstract class BasePresenter
    {
        public IActionResult ViewModel { get; protected set; }

        public void UnhandledException(Exception ex)
        {
            ViewModel = new StatusCodeResult(500);
        }
    }
}
