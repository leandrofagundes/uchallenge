using UChallenge.Domain.FeiraLivreAggregates;
using UChallenge.Domain.FeiraLivreAggregates.Queryables;
using UChallenge.Framework.Application.Extensions;
using UChallenge.Framework.Domain.Repositories;
using UChallenge.Framework.Tests.Fixtures;
using UChallenge.MockDB;
using UChallenge.MockDB.FeiraLivreAggregates;
using UChallenge.MockDB.Queryables;

namespace UChallenge.Application.Tests.Fixtures
{
    public sealed class V1Fixtures :
        BaseFixture
    {
        private readonly MockDbContext _context = new();

        public readonly IFeiraLivreFactory FeiraLivreFactory;
        public readonly IFeiraLivreRepository FeiraLivreRepository;
        public readonly IFeiraLivreQueryable FeiraLivreQueryable;
        public readonly IUnitOfWork UnitOfWork;

        public V1Fixtures()
        {
            _context.Seed();

            FeiraLivreFactory = new FeiraLivreFactory();
            FeiraLivreRepository = new FeiraLivreRepository(_context);
            FeiraLivreQueryable = new FeiraLivreQueryable(_context);

            UnitOfWork = new MockUnitOfWork();
        }
    }
}
