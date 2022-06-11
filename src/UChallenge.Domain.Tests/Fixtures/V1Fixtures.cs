using UChallenge.Domain.FeiraLivreAggregates;
using UChallenge.Framework.Domain.ValueObjects;
using UChallenge.Framework.Tests.Fixtures;

namespace UChallenge.Domain.Tests.Fixtures
{
    public sealed class V1Fixtures :
        BaseFixture
    {
        public readonly FeiraLivre FeiraLivreVLFORMOSA;
        public readonly IFeiraLivreFactory FeiraLivreFactory;

        public V1Fixtures()
        {
            FeiraLivreFactory = new MockDB.FeiraLivreAggregates.FeiraLivreFactory();
            FeiraLivreVLFORMOSA = BuildFeiraLivreVLFORMOSA();
        }

        private FeiraLivre BuildFeiraLivreVLFORMOSA()
        {
            return FeiraLivreFactory.Create(
                1,
                "VILA FORMOSA",
                "4041-0",
                new Longitude(-46.550164),
                new Latitude(-23.558733),
                355030885000091,
                3550308005040,
                87, "VILA FORMOSA",
                26, "ARICANDUVA-FORMOSA-CARRAO",
                "Leste", "Leste 1",
                "RUA MARAGOJIPE",
                "S/N",
                "VL FORMOSA",
                "TV RUA PRETORIA");
        }
    }
}
