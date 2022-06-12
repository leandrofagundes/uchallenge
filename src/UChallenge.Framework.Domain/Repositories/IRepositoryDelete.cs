using UChallenge.Framework.Domain.Models;

namespace UChallenge.Framework.Domain.Repositories
{
    public interface IRepositoryDelete<TEntity, UniqueIdentifier>
        where TEntity : IAggregateRoot
        where UniqueIdentifier : struct
    {
        void Remove(TEntity entity);
    }
}
