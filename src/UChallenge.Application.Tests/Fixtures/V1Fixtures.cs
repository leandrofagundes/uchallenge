using UChallenge.Framework.Application.Extensions;
using UChallenge.Framework.Domain.Repositories;
using UChallenge.Framework.Tests.Fixtures;
using UChallenge.MockDB;
using UChallenge.MockDB.FeiraLivreAggregates;

namespace UChallenge.Application.Tests.Fixtures
{
    public sealed class V1Fixtures :
        BaseFixture
    {
        private readonly MockDbContext _context = new();

        public readonly Domain.FeiraLivreAggregates.IFeiraLivreFactory FeiraLivreFactory;
        public readonly Domain.FeiraLivreAggregates.IFeiraLivreRepository FeiraLivreRepository;
        public readonly IUnitOfWork UnitOfWork;

        public V1Fixtures()
        {
            _context.Seed();

            FeiraLivreFactory = new FeiraLivreFactory();
            FeiraLivreRepository = new FeiraLivreRepository(_context);

            UnitOfWork = new MockUnitOfWork();
        }
    }
}
