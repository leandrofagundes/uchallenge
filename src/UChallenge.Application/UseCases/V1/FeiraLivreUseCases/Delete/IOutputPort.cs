using UChallenge.Framework.Application.UseCases;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Delete
{
    public interface IOutputPort :
        IOutputPortSuccess,
        IOutputPortEntityNotFound,
        IOutputPortUnhandledException
    {
    }
}
