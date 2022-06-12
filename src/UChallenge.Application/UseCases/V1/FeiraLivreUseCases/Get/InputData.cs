using UChallenge.Framework.Application.UseCases;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Get
{
    public sealed record InputData :
        BaseInputData
    {
        public readonly string Nome;
        public readonly string NomeDistrito;
        public readonly string RegiaoDivisaoEm5Areas;
        public readonly string Bairro;

        public InputData(
            string nome,
            string nomeDistrito,
            string regiaoDivisaoEm5Areas,
            string bairro)
        {
            Nome = nome;
            NomeDistrito = nomeDistrito;
            RegiaoDivisaoEm5Areas = regiaoDivisaoEm5Areas;
            Bairro = bairro;
        }
    }
}
