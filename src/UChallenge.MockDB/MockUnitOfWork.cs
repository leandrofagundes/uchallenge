using System.Threading.Tasks;
using UChallenge.Framework.Domain.Repositories;

namespace UChallenge.MockDB
{
    public sealed  class MockUnitOfWork :
        IUnitOfWork
    {
        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
