using System.Threading;
using System.Threading.Tasks;

namespace UChallenge.Framework.Application.UseCases
{
    public interface IUseCaseCancellable<in TUseCaseInputData>
         where TUseCaseInputData : BaseInputData
    {
        Task RequestAsync(TUseCaseInputData inputData, CancellationToken cancellationToken);
    }
}
