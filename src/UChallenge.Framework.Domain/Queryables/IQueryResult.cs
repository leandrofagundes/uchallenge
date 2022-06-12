using System.Collections.Generic;

namespace UChallenge.Framework.Domain.Queryables
{
    public interface IQueryResult<TQueryResultData>
        where TQueryResultData : IQueryResultData
    {
        IEnumerable<TQueryResultData> Items { get; }
    }
}
