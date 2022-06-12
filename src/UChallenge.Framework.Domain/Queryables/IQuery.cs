namespace UChallenge.Framework.Domain.Queryables
{
    public interface IQuery<TResult> : IQueryResult<TResult>
        where TResult : IQueryResultData
    {
    }
}
