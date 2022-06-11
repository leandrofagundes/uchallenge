using UChallenge.Framework.Domain.Models;

namespace UChallenge.MSSQL
{
    public abstract class BaseRepository<TEntity, TUniqueIdentifier>
        where TEntity : IAggregateRoot
        where TUniqueIdentifier : struct
    {
        protected readonly MSSqlServerDbContext Context;

        public BaseRepository(MSSqlServerDbContext context)
        {
            Context = context;
        }
    }
}
