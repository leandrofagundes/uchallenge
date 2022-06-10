using UChallenge.Framework.Domain.ValueObjects;
using UChallenge.MockDB.FeiraLivreAggregates;
using Xunit;

namespace UChallenge.Domain.Tests.UnitTests.FeiraLivreTests
{
    public sealed class FeiraLivreUnitTests
    {
        [Fact]
        public void Create_FeiraLivre_ShouldSuccess()
        {
            // arrange
            var feiraLivre = new FeiraLivre(
                921,
                "Feira Test",
                "R-0921",
                "Fair Avenue",
                "921",
                "District 9",
                "In front of Blockbuster",
                9,
                "District 9",
                new Longitude(-23.520302),
                new Latitude(-21.003920),
                1,
                1,
                1,
                "Subcity",
                "REGION 5",
                "REGION 8");

            // assert
            Assert.NotNull(feiraLivre);
        }
    }
}
