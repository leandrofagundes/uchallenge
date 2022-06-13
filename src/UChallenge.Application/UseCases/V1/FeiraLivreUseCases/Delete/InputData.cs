using UChallenge.Framework.Application.UseCases;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Delete
{
    public sealed record InputData :
        BaseInputData
    {
        public readonly int Id;

        public InputData(int id)
        {
            Id = id;
        }
    }
}
