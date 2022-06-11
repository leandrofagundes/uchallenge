using System.Threading.Tasks;
using UChallenge.Framework.Domain.Repositories;

namespace UChallenge.Domain.FeiraLivreAggregates
{
    public sealed class FeiraLivreRepository :
        IRepository<FeiraLivre, long>
    {
        public Task AddAsync(FeiraLivre entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExistsAsync(long key)
        {
            throw new System.NotImplementedException();
        }

        public Task<FeiraLivre> FindAsync(long key)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(FeiraLivre entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(FeiraLivre entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
