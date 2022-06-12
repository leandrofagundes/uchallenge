using System.Threading.Tasks;
using UChallenge.Application.Tests.Fixtures;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Get;
using UChallenge.Framework.Tests.Fixtures;
using Xunit;

namespace UChallenge.Application.Tests.UseCases.V1.FeiraLivreIntegrationTests
{
    public sealed class GetTests :
        BaseIntegrationTests<V1Fixtures>
    {
        public GetTests(V1Fixtures fixtures) :
            base(fixtures)
        {

        }

        [Theory]
        [InlineData("", "", "", "")]
        [InlineData("VILA", "", "", "")]
        [InlineData("POMPÉIA", "", "", "")]
        [InlineData("", "VILA", "", "")]
        [InlineData("", "", "leste", "")]
        [InlineData("", "", "", "vL")]
        public async Task Get_FeiraLivreUseCase_ShouldSuccess(string nome, string distrito, string regiao5, string bairro)
        {
            // arrange
            var presenter = new GetPresenter();
            var useCase = new UseCase(
                Fixtures.FeiraLivreQueryable,
                presenter);

            var inputData = new InputData(nome, distrito, regiao5, bairro);

            // act
            await useCase
                .RequestAsync(inputData)
                .ConfigureAwait(false);

            // assert
            Assert.NotNull(presenter.OutputData);
            Assert.NotEmpty(presenter.OutputData.Items);

        }


        [Theory]
        [InlineData("VALO", "", "", "")]
        [InlineData("POMPEIA", "", "", "")]
        [InlineData("", "valo", "", "")]
        [InlineData("", "", "oeste", "")]
        [InlineData("", "", "", "ZL")]
        public async Task Get_FeiraLivreUseCase_ShouldReturnEmpty(string nome, string distrito, string regiao5, string bairro)
        {
            // arrange
            var presenter = new GetPresenter();
            var useCase = new UseCase(
                Fixtures.FeiraLivreQueryable,
                presenter);

            var inputData = new InputData(nome, distrito, regiao5, bairro);

            // act
            await useCase
                .RequestAsync(inputData)
                .ConfigureAwait(false);

            // assert
            Assert.NotNull(presenter.OutputData);
            Assert.Empty(presenter.OutputData.Items);

        }
    }
}
