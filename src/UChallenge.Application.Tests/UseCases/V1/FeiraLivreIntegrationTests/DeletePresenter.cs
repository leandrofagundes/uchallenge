using System;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Delete;
using UChallenge.Framework.Application.Exceptions;

namespace UChallenge.Application.Tests.UseCases.V1.FeiraLivreIntegrationTests
{
    public sealed class DeletePresenter :
        IOutputPort
    {
        public bool IsSucceed { get; private set; }

        public void NotFound(object value)
        {
            IsSucceed = false;
            throw new BusinessApplicationRecordNotFoundException(value);
        }

        public void Success()
        {
            IsSucceed = true;
        }

        public void UnhandledException(Exception ex)
        {
            IsSucceed = false;
            throw ex;
        }
    }
}
