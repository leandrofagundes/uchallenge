using UChallenge.Framework.Domain.ValueObjects;

namespace UChallenge.MSSQL.FeiraLivreAggregates
{
    public sealed record FeiraLivre :
        Domain.FeiraLivreAggregates.FeiraLivre
    {
        internal FeiraLivre(
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
            string referencia) : base(
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
                referencia)
        {
        }
    }
}
