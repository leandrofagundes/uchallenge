using UChallenge.Domain.FeiraLivreAggregates;
using UChallenge.Framework.Domain.ValueObjects;

namespace UChallenge.MockDB.FeiraLivreAggregates
{
    public sealed class FeiraLivreFactory :
        IFeiraLivreFactory
    {
        public Domain.FeiraLivreAggregates.FeiraLivre Create(
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
            string referencia)
        {
            return new FeiraLivre(
                id,
                nome,
                registro,
                longitude,
                latitude,
                setorCensitario,
                areaPonderacao,
                codigoDistrito,
                nomeDistrito,
                codigoSubPrefeitura,
                nomeSubPrefeitura,
                regiaoDivisaoEm5Areas,
                regiaoDivisaoEm8Areas,
                logradouro,
                numero,
                bairro,
                referencia);
        }
    }
}
