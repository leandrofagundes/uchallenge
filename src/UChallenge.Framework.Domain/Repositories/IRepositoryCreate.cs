using System.Threading.Tasks;
using UChallenge.Framework.Domain.Models;

namespace UChallenge.Framework.Domain.Repositories
{
    public interface IRepositoryCreate<TEntity, UniqueIdentifier>
        where TEntity : IAggregateRoot
        where UniqueIdentifier : struct
    {
        public Task AddAsync(TEntity entity);
    }
}
