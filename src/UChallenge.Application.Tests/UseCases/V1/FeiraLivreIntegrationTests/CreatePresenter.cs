using System;
using System.Collections.Generic;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Create;
using UChallenge.Framework.Application.Exceptions;
using UChallenge.Framework.Domain.Exceptions;

namespace UChallenge.Application.Tests.UseCases.V1.FeiraLivreIntegrationTests
{
    internal class CreatePresenter :
        IOutputPort
    {
        public OutputData OutputData { get; private set; }

        public void InvalidEntityData(string message)
        {
            OutputData = null;
            throw new DomainFieldException(message);
        }

        public void InvalidInputData(Dictionary<string, string> errors)
        {
            OutputData = null;
            throw new BusinessApplicationInvalidInputDataException(errors);
        }

        public void Success(OutputData outputData)
        {
            OutputData = outputData;
        }

        public void UnhandledException(Exception ex)
        {
            throw ex;
        }
    }
}
