using System;
using System.Collections.Generic;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Update;
using UChallenge.Framework.Application.Exceptions;
using UChallenge.Framework.Domain.Exceptions;

namespace UChallenge.Application.Tests.UseCases.V1.FeiraLivreIntegrationTests
{
    public sealed class UpdatePresenter :
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

        public void NotFound(object value)
        {
            OutputData = null;
            throw new BusinessApplicationRecordNotFoundException(value);
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
