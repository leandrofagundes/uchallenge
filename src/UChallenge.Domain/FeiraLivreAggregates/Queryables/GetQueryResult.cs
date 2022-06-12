using System.Collections.Generic;
using UChallenge.Framework.Domain.Queryables;

namespace UChallenge.Domain.FeiraLivreAggregates.Queryables
{
    public sealed class GetQueryResult :
        IQueryResult<GetQueryResultItem>
    {
        public IEnumerable<GetQueryResultItem> Items { get; private set; }

        public GetQueryResult(IEnumerable<GetQueryResultItem> items)
        {
            Items = items;
        }
    }
}
