using UChallenge.Framework.Application.UseCases;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Get
{
    public sealed record InputData :
        BaseInputData
    {
        public readonly string NomeFeira;
        public readonly int CodigoDistrito;
        public readonly string NomeDistrito;
        public readonly string RegiaoPorDivisaoEm5Areas;
        public readonly string Bairro;

        public InputData(
            string nomeFeira,
            int codigoDistrito,
            string nomeDistrito,
            string regiaoPorDivisaoEm5Areas,
            string bairro)
        {
            NomeFeira = nomeFeira;
            CodigoDistrito = codigoDistrito;
            NomeDistrito = nomeDistrito;
            RegiaoPorDivisaoEm5Areas = regiaoPorDivisaoEm5Areas;
            Bairro = bairro;
        }
    }
}
