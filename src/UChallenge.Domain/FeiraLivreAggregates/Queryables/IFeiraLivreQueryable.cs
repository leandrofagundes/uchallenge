using System.Threading.Tasks;
using UChallenge.Framework.Domain.Queryables;

namespace UChallenge.Domain.FeiraLivreAggregates.Queryables
{
    public interface IFeiraLivreQueryable :
        IQueryable
    {
        Task<GetQueryResult> Get(GetQueryFilter queryFilter);
    }
}
