using UChallenge.Framework.Application.UseCases;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Get
{
    public interface IOutputPort :
        IOutputPortSuccess<OutputData>,
        IOutputPortUnhandledException
    {
    }
}
