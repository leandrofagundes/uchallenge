using UChallenge.Framework.Domain.ValueObjects;

namespace UChallenge.Domain.FeiraLivreAggregates
{
    public interface IFeiraLivreFactory
    {
        FeiraLivre Create(
            int id,
            string nome,
            string registro,
            Longitude longitude,
            Latitude latitude,
            int setorCensitario,
            long areaPonderacao,
            int codigoDistrito,
            string nomeDistrito,
            int codigoSubPrefeitura,
            string nomeSubPrefeitura,
            string regiaoDivisaoEm5Areas,
            string regiaoDivisaoEm8Areas,
            string logradouro,
            string numero,
            string bairro,
            string referencia);
    }
}
