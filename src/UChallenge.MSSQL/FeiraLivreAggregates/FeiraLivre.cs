using UChallenge.Framework.Domain.ValueObjects;

namespace UChallenge.MSSQL.FeiraLivreAggregates
{
    public sealed record FeiraLivre :
        Domain.FeiraLivreAggregates.FeiraLivre
    {
        internal FeiraLivre(
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
            string referencia) : base(
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
                referencia)
        {
        }
    }
}
