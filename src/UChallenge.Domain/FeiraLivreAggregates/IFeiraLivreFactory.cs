using UChallenge.Framework.Domain.ValueObjects;

namespace UChallenge.Domain.FeiraLivreAggregates
{
    public interface IFeiraLivreFactory
    {
        FeiraLivre Create(long id,
            string nomeFeira,
            string registroFeira,
            string logradouro,
            string numero,
            string bairro,
            string referencia,
            long codigoDistrito,
            string nomeDistrito,
            Longitude longitude,
            Latitude latitude,
            long setorCensitario,
            long areaDePonderacao,
            int codigoSubPrefeitura,
            string nomeSubPrefeitura,
            string regiaoPorDivisaoEm5Areas,
            string regiaoPorDivisaoEm8Areas);
    }
}
