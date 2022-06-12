using UChallenge.Framework.Application.UseCases;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Delete
{
    public sealed record InputData :
        BaseInputData
    {
        public readonly long Id;

        public InputData(long id)
        {
            Id = id;
        }
    }
}
