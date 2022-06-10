using UChallenge.Framework.Domain.ValueObjects;
using UChallenge.Framework.Tests.Fixtures;
using UChallenge.MockDB.FeiraLivreAggregates;

namespace UChallenge.Domain.Tests.Fixtures
{
    public sealed class V1Fixtures :
        BaseFixture
    {
        public readonly FeiraLivre FeiraLivreVLFORMOSA;

        public V1Fixtures()
        {
            FeiraLivreVLFORMOSA = BuildFeiraLivreVLFORMOSA();
        }

        private static FeiraLivre BuildFeiraLivreVLFORMOSA()
        {
            return new FeiraLivre(
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
