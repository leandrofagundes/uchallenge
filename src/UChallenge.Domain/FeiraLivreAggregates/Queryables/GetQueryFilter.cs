using UChallenge.Framework.Domain.Queryables;

namespace UChallenge.Domain.FeiraLivreAggregates.Queryables
{
    public sealed class GetQueryFilter :
        IQueryFilter
    {
        public string Nome { get; init; }
        public string NomeDistrito { get; init; }
        public string RegiaoEm5Areas { get; init; }
        public string Bairro { get; init; }
    }
}
