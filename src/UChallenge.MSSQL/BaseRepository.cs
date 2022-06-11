using System.Threading.Tasks;
using UChallenge.Framework.Domain.Models;

namespace UChallenge.MSSQL
{
    public abstract class BaseRepository<TAbstract, TEntity, TUniqueIdentifier>
        where TAbstract : BaseEntity<TUniqueIdentifier>
        where TEntity : BaseEntity<TUniqueIdentifier>, TAbstract
        where TUniqueIdentifier : struct
    {
        protected readonly MSSqlServerDbContext Context;

        public BaseRepository(MSSqlServerDbContext context)
        {
            Context = context;
        }

        public async Task AddAsync(TAbstract entity)
        {
            await Context
                .Set<TEntity>()
                .AddAsync((TEntity)entity)
                .ConfigureAwait(false);
        }

        public async Task<TAbstract> FindAsync(TUniqueIdentifier key)
        {
            var entity = await Context
                .Set<TEntity>()
                .FindAsync(key)
                .ConfigureAwait(false);

            return entity;
        }

        public async Task<bool> ExistsAsync(TUniqueIdentifier key)
        {
            var entity = await Context
                .Set<TEntity>()
                .FindAsync(key)
                .ConfigureAwait(false);

            if (entity is null)
                return false;
            else
                return true;
        }

        public void Remove(TAbstract entity)
        {
            Context
                .Set<TEntity>()
                .Remove((TEntity)entity);
        }
        public void Update(TAbstract entity)
        {
            Context
                .Set<TEntity>()
                .Update((TEntity)entity);
        }
    }
}
