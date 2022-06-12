using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UChallenge.Framework.Domain.Models;

namespace UChallenge.MockDB
{
    public abstract class BaseRepository<TAbstract, TEntity, TUniqueIdentifier>
        where TAbstract : BaseEntity<TUniqueIdentifier>
        where TEntity : BaseEntity<TUniqueIdentifier>, TAbstract
        where TUniqueIdentifier : struct
    {
        private readonly List<TEntity> _dbSet;

        public BaseRepository(List<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public async Task AddAsync(TAbstract entity)
        {
            _dbSet.Add((TEntity)entity);
            await Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(TUniqueIdentifier key)
        {
            var exists = _dbSet.Any(entity => entity.Id.Equals(key));
            return Task.FromResult(exists);
        }

        public Task<TAbstract> FindAsync(TUniqueIdentifier key)
        {
            var entity = _dbSet.FirstOrDefault(entity => entity.Id.Equals(key));
            return Task.FromResult((TAbstract)entity);
        }

        public void Remove(TAbstract entity)
        {
            _dbSet.Remove((TEntity)entity);
        }

        public void Update(TAbstract entity)
        {
            var entityInDb = _dbSet.FirstOrDefault(entity => entity.Id.Equals(entity.Id));
            entityInDb = (TEntity)entity;
        }
    }
}
