namespace UChallenge.Framework.Application.Queries
{
    public interface IQuery<TResult> : IQueryResult<TResult>
        where TResult : IQueryResultData
    {
    }
}
