using UChallenge.Domain.FeiraLivreAggregates;
using UChallenge.Framework.Domain.ValueObjects;

namespace UChallenge.MSSQL.FeiraLivreAggregates
{
    public sealed class FeiraLivreFactory :
        IFeiraLivreFactory
    {
        public Domain.FeiraLivreAggregates.FeiraLivre Create(
            long id,
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
            string referencia)
        {
            return new FeiraLivre(
                id,
                nomeFeira,
                registroFeira,
                longitude,
                latitude,
                setorCensitario,
                areaDePonderacao,
                codigoDistrito,
                nomeDistrito,
                codigoSubPrefeitura,
                nomeSubPrefeitura,
                regiaoPorDivisaoEm5Areas,
                regiaoPorDivisaoEm8Areas,
                logradouro,
                numero,
                bairro,
                referencia);
        }
    }
}
