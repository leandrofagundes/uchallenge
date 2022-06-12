using UChallenge.Framework.Domain.Models;

namespace UChallenge.Framework.Domain.Repositories
{
    public interface IRepository<TAggregateRoot, UniqueIdentifier> :
        IRepositoryCreate<TAggregateRoot, UniqueIdentifier>,
        IRepositoryRead<TAggregateRoot, UniqueIdentifier>,
        IRepositoryUpdate<TAggregateRoot, UniqueIdentifier>,
        IRepositoryDelete<TAggregateRoot, UniqueIdentifier>
        where TAggregateRoot : IAggregateRoot
        where UniqueIdentifier : struct
    {
    }
}
