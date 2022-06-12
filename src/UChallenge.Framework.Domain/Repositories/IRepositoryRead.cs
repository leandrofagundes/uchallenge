using System.Threading.Tasks;
using UChallenge.Framework.Domain.Models;

namespace UChallenge.Framework.Domain.Repositories
{
    public interface IRepositoryRead<TEntity, UniqueIdentifier>
        where TEntity : IAggregateRoot
        where UniqueIdentifier : struct
    {
        Task<TEntity> FindAsync(UniqueIdentifier key);
        Task<bool> ExistsAsync(UniqueIdentifier key);
    }
}
