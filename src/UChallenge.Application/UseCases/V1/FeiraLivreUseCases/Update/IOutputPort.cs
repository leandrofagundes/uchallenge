using UChallenge.Framework.Application.UseCases;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Update
{
    public interface IOutputPort :
        IOutputPortSuccess<OutputData>,
        IOutputPortInvalidEntityData,
        IOutputPortInvalidInputData,
        IOutputPortEntityNotFound,
        IOutputPortUnhandledException
    {
    }
}
