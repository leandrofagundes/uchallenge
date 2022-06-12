using System.Threading.Tasks;
using UChallenge.Framework.Domain.Repositories;

namespace UChallenge.MSSQL
{
    public sealed class MSSqlServerUnitOfWork :
        IUnitOfWork
    {
        private readonly MSSqlServerDbContext _context;

        public MSSqlServerUnitOfWork(MSSqlServerDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}
