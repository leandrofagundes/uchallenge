using System.Threading.Tasks;

namespace UChallenge.Framework.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
