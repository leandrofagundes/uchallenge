using System;
using UChallenge.Framework.Domain.ValueObjects;
using UChallenge.MockDB.FeiraLivreAggregates;

namespace UChallenge.Domain.Tests.Fixtures
{
    internal sealed class V1Fixtures
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
                "RUA MARAGOJIPE",
                "S/N",
                "VL FORMOSA",
                "TV RUA PRETORIA",
                87, "VILA FORMOSA",
                new Longitude(-46.550164),
                new Latitude(-23.558733),
                355030885000091,
                3550308005040,
                26, "ARICANDUVA-FORMOSA-CARRAO",
                "Leste", "Leste 1");
        }
    }
}
