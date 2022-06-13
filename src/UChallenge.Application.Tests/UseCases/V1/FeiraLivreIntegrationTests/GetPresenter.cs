using System;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Get;

namespace UChallenge.Application.Tests.UseCases.V1.FeiraLivreIntegrationTests
{
    public sealed class GetPresenter :
        IOutputPort
    {
        public OutputData OutputData { get; private set; }

        public void OperationCancelled()
        {
            OutputData = null;
            throw new OperationCanceledException();
        }

        public void Success(OutputData outputData)
        {
            OutputData = outputData;
        }

        public void UnhandledException(Exception ex)
        {
            OutputData = null;
            throw ex;
        }
    }
}
