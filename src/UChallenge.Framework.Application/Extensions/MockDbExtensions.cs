using System.Collections.Generic;
using UChallenge.Framework.Domain.ValueObjects;
using UChallenge.MockDB;
using UChallenge.MockDB.FeiraLivreAggregates;

namespace UChallenge.Framework.Application.Extensions
{
    public static class MockDbExtensions
    {
        public static void Seed(this MockDbContext context)
        {
            context.FeirasLivres.AddRange(BuildFeirasLivres());
        }

        private static IEnumerable<FeiraLivre> BuildFeirasLivres()
        {
            var feiraLivreFactory = new FeiraLivreFactory();

            var feirasLivre = new List<FeiraLivre>(2)
            {
                (FeiraLivre)feiraLivreFactory.Create(
                1,
                "VILA FORMOSA",
                "4041-0",
                new Longitude(-46.550164),
                new Latitude(-23.558733),
                298378139,
                3550308005040,
                87, "VILA FORMOSA",
                26, "ARICANDUVA-FORMOSA-CARRAO",
                "Leste", "Leste 1",
                "RUA MARAGOJIPE",
                "S/N",
                "VL FORMOSA",
                "TV RUA PRETORIA"),

                (FeiraLivre)feiraLivreFactory.Create(
                5,
                "VILA POMPÉIA",
                "4042-0",
                new Longitude(-46.550164),
                new Latitude(-23.558733),
                298378139,
                3550308005040,
                87, "VILA POMPÉIA",
                26, "ARICANDUVA-POMPEIA-CARRAO",
                "Leste", "Leste 1",
                "RUA DA VILA",
                "S/N",
                "VL POMPEIA",
                "ESQUINA DA CURVA")
            };

            return feirasLivre;
        }
    }
}
