using UChallenge.Framework.Application.UseCases;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Create
{
    public interface IOutputPort :
        IOutputPortSuccess<OutputData>,
        IOutputPortInvalidEntityData,
        IOutputPortInvalidInputData,
        IOutputPortUnhandledException
    {
    }
}
