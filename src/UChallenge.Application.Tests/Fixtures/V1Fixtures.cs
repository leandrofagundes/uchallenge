﻿using UChallenge.Domain.FeiraLivreAggregates;
using UChallenge.Framework.Domain.Repositories;
using UChallenge.Framework.Tests.Fixtures;
using UChallenge.MockDB;
using UChallenge.MockDB.FeiraLivreAggregates;

namespace UChallenge.Application.Tests.Fixtures
{
    public sealed class V1Fixtures :
        BaseFixture
    {
        private static MockDbContext _context = new();

        public readonly IFeiraLivreFactory FeiraLivreFactory;
        public readonly IFeiraLivreRepository FeiraLivreRepository;
        public readonly IUnitOfWork UnitOfWork;

        public V1Fixtures()
        {
            FeiraLivreFactory = new FeiraLivreFactory();
            FeiraLivreRepository = new FeiraLivreRepository(_context);

            UnitOfWork = new MockUnitOfWork();
        }


    }
}
