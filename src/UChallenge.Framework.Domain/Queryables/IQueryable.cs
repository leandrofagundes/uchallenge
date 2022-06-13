using System.Threading.Tasks;

namespace UChallenge.Framework.Domain.Queryables
{
    public interface IQueryable
    {
        Task InvalidateAsync();
    }
}
