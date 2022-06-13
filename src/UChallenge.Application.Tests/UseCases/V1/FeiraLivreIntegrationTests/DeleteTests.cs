using System.Threading.Tasks;
using UChallenge.Application.Tests.Fixtures;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Delete;
using UChallenge.Framework.Application.Exceptions;
using UChallenge.Framework.Tests.Fixtures;
using Xunit;

namespace UChallenge.Application.Tests.UseCases.V1.FeiraLivreIntegrationTests
{
    public sealed class DeleteTests :
        BaseIntegrationTests<V1Fixtures>
    {
        public DeleteTests(V1Fixtures fixtures) :
            base(fixtures)
        {
        }

        [Theory]
        [InlineData(1)]
        public async Task Delete_FeiraLivreUseCase_ShouldSuccess(int id)
        {
            // arrange
            var presenter = new DeletePresenter();
            var useCase = new UseCase(
                Fixtures.FeiraLivreRepository,
                Fixtures.UnitOfWork,
                presenter);

            var inputData = new InputData(id);

            // act
            await useCase
                .RequestAsync(inputData)
                .ConfigureAwait(false);

            // assert
            Assert.True(presenter.IsSucceed);

        }

        [Theory]
        [InlineData(1000)]
        [InlineData(1001)]
        public async Task Update_FeiraLivreUseCase_ShouldThrows_NotFoundException(int id)
        {
            // arrange
            var presenter = new DeletePresenter();
            var useCase = new UseCase(
                Fixtures.FeiraLivreRepository,
                Fixtures.UnitOfWork,
                presenter);

            var inputData = new InputData(id);

            // act
            // assert
            await Assert.ThrowsAsync<BusinessApplicationRecordNotFoundException>(
                () => useCase.RequestAsync(inputData));
        }
    }
}
