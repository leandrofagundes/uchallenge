using UChallenge.Framework.Domain.ValueObjects;

namespace UChallenge.Domain.FeiraLivreAggregates
{
    public interface IFeiraLivreFactory
    {
        FeiraLivre Create(long id,
            string nomeFeira,
            string registroFeira,
            Longitude longitude,
            Latitude latitude,
            long setorCensitario,
            long areaDePonderacao,
            int codigoDistrito,
            string nomeDistrito,
            int codigoSubPrefeitura,
            string nomeSubPrefeitura,
            string regiaoPorDivisaoEm5Areas,
            string regiaoPorDivisaoEm8Areas,
            string logradouro,
            string numero,
            string bairro,
            string referencia);
    }
}
