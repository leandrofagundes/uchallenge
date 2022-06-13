using System.Linq;
using System.Threading.Tasks;
using UChallenge.Domain.FeiraLivreAggregates.Queryables;

namespace UChallenge.MockDB.Queryables
{
    public sealed class FeiraLivreQueryable :
        IFeiraLivreQueryable
    {
        private readonly MockDbContext _context;

        public FeiraLivreQueryable(MockDbContext context)
        {
            _context = context;
        }

        public Task<GetQueryResult> Get(GetQueryFilter queryFilter)
        {
            var items = _context.FeirasLivres.Select(item => new GetQueryResultItem(
                item.Id,
                item.Nome,
                item.Registro,
                item.Longitude.ToDouble(),
                item.Latitude.ToDouble(),
                item.SetorCensitario,
                item.AreaPonderacao,
                item.CodigoDistrito,
                item.NomeDistrito,
                item.CodigoSubPrefeitura,
                item.NomeSubPrefeitura,
                item.RegiaoDivisaoEm5Areas,
                item.RegiaoDivisaoEm8Areas,
                item.Logradouro,
                item.Numero,
                item.Bairro,
                item.Referencia)).AsQueryable();

            if (!string.IsNullOrEmpty(queryFilter.Nome))
                items = items.Where(item => item.Nome.ToUpper().Contains(queryFilter.Nome.ToUpper()));
            if (!string.IsNullOrEmpty(queryFilter.Bairro))
                items = items.Where(item => item.Bairro.ToUpper().Contains(queryFilter.Bairro.ToUpper()));
            if (!string.IsNullOrEmpty(queryFilter.NomeDistrito))
                items = items.Where(item => item.NomeDistrito.ToUpper().Contains(queryFilter.NomeDistrito.ToUpper()));
            if (!string.IsNullOrEmpty(queryFilter.RegiaoEm5Areas))
                items = items.Where(item => item.RegiaoDivisaoEm5Areas.ToUpper().Contains(queryFilter.RegiaoEm5Areas.ToUpper()));

            var result = new GetQueryResult(items.ToList());
            return Task.FromResult(result);
        }

        public Task InvalidateAsync()
        {
            return Task.CompletedTask;
        }
    }
}
