using UChallenge.Framework.Domain.Models;

namespace UChallenge.Framework.Domain.Repositories
{
    public interface IRepositoryUpdate<TEntity, UniqueIdentifier>
        where TEntity : IAggregateRoot
        where UniqueIdentifier : struct
    {
        void Update(TEntity entity);
    }
}
