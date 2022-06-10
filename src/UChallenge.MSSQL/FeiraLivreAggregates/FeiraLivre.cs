using UChallenge.Framework.Domain.ValueObjects;

namespace UChallenge.MSSQL.FeiraLivreAggregates
{
    public sealed record FeiraLivre :
        Domain.FeiraLivreAggregates.FeiraLivre
    {
        public FeiraLivre(
            long id,
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
            int setorCensitario,
            long areaDePonderacao,
            int codigoSubPrefeitura,
            string nomeSubPrefeitura,
            string regiaoPorDivisaoEm5Areas,
            string regiaoPorDivisaoEm8Areas) :
            base(
                id,
                nomeFeira,
                registroFeira,
                logradouro,
                numero,
                bairro,
                referencia,
                codigoDistrito,
                nomeDistrito,
                longitude,
                latitude,
                setorCensitario,
                areaDePonderacao,
                codigoSubPrefeitura,
                nomeSubPrefeitura,
                regiaoPorDivisaoEm5Areas,
                regiaoPorDivisaoEm8Areas)
        {
        }
    }
}
