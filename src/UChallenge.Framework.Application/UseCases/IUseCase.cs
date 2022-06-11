using System.Threading.Tasks;

namespace UChallenge.Framework.Application.UseCases
{
    public interface IUseCase<in TUseCaseInputData>
        where TUseCaseInputData : BaseInputData
    {
        Task RequestAsync(TUseCaseInputData inputData);
    }
}
