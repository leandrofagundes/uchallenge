using System.Threading.Tasks;
using UChallenge.Application.Tests.Fixtures;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Update;
using UChallenge.Framework.Application.Exceptions;
using UChallenge.Framework.Domain.Exceptions;
using UChallenge.Framework.Tests.Fixtures;
using Xunit;

namespace UChallenge.Application.Tests.UseCases.V1.FeiraLivreIntegrationTests
{
    public sealed class UpdateTests :
        BaseIntegrationTests<V1Fixtures>
    {
        public UpdateTests(V1Fixtures fixtures) :
            base(fixtures)
        {
        }

        [Theory]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(5, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "", "referencia")]
        public async Task Update_FeiraLivreUseCase_ShouldSuccess(
            int id,
            string nome,
            string registro,
            double longitude,
            double latitude,
            int setorCensitario,
            long areaPonderacao,
            int codigoDistrito,
            string nomeDistrito,
            int codigoSubPrefeitura,
            string nomeSubPrefeitura,
            string regiaoDivisaoEm5Areas,
            string regiaoDivisaoEm8Areas,
            string logradouro,
            string numero,
            string bairro,
            string referencia)
        {
            // arrange
            var presenter = new UpdatePresenter();
            var useCase = new UseCase(
                Fixtures.FeiraLivreRepository,
                Fixtures.UnitOfWork,
                presenter);

            var inputData = new InputData(
                id,
                nome,
                registro,
                longitude,
                latitude,
                setorCensitario,
                areaPonderacao,
                codigoDistrito,
                nomeDistrito,
                codigoSubPrefeitura,
                nomeSubPrefeitura,
                regiaoDivisaoEm5Areas,
                regiaoDivisaoEm8Areas,
                logradouro,
                numero,
                bairro,
                referencia);

            // act
            await useCase
                .RequestAsync(inputData)
                .ConfigureAwait(false);

            // assert
            var outputData = presenter.OutputData;

            Assert.NotNull(outputData);
            Assert.Equal(inputData.Id, outputData.Id);
            Assert.Equal(inputData.Nome, outputData.Nome);

        }

        [Theory]
        [InlineData(1, "Nome", "Registro", -91, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", 91, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, 181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        public async Task Update_FeiraLivreUseCase_ShouldThrows_InvalidInputDataException(
            int id,
            string nome,
            string registro,
            double latitude,
            double longitude,
            int setorCensitario,
            long areaPonderacao,
            int codigoDistrito,
            string nomeDistrito,
            int codigoSubPrefeitura,
            string nomeSubPrefeitura,
            string regiaoDivisaoEm5Areas,
            string regiaoDivisaoEm8Areas,
            string logradouro,
            string numero,
            string bairro,
            string referencia)
        {
            // arrange
            var presenter = new UpdatePresenter();
            var useCase = new UseCase(
                Fixtures.FeiraLivreRepository,
                Fixtures.UnitOfWork,
                presenter);

            var inputData = new InputData(
                id,
                nome,
                registro,
                longitude,
                latitude,
                setorCensitario,
                areaPonderacao,
                codigoDistrito,
                nomeDistrito,
                codigoSubPrefeitura,
                nomeSubPrefeitura,
                regiaoDivisaoEm5Areas,
                regiaoDivisaoEm8Areas,
                logradouro,
                numero,
                bairro,
                referencia);

            // act
            // assert
            await Assert.ThrowsAsync<BusinessApplicationInvalidInputDataException>(
                () => useCase.RequestAsync(inputData));
        }

        [Theory]
        [InlineData(1, "", "R1234", -25.234, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "", -25.234, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 0, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 0, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 0, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 0, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "", "1", "bairro", "referencia")]
        public async Task Update_FeiraLivreUseCase_ShouldThrows_DomainFieldException(
            int id,
            string nome,
            string registro,
            double latitude,
            double longitude,
            int setorCensitario,
            long areaPonderacao,
            int codigoDistrito,
            string nomeDistrito,
            int codigoSubPrefeitura,
            string nomeSubPrefeitura,
            string regiaoDivisaoEm5Areas,
            string regiaoDivisaoEm8Areas,
            string logradouro,
            string numero,
            string bairro,
            string referencia)
        {
            // arrange
            var presenter = new UpdatePresenter();
            var useCase = new UseCase(
                Fixtures.FeiraLivreRepository,
                Fixtures.UnitOfWork,
                presenter);

            var inputData = new InputData(
                id,
                nome,
                registro,
                longitude,
                latitude,
                setorCensitario,
                areaPonderacao,
                codigoDistrito,
                nomeDistrito,
                codigoSubPrefeitura,
                nomeSubPrefeitura,
                regiaoDivisaoEm5Areas,
                regiaoDivisaoEm8Areas,
                logradouro,
                numero,
                bairro,
                referencia);

            // act
            // assert
            await Assert.ThrowsAnyAsync<DomainFieldException>(
                () => useCase.RequestAsync(inputData));
        }

        [Theory]
        [InlineData(998, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(999, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "", "bairro", "referencia")]
        public async Task Update_FeiraLivreUseCase_ShouldThrows_NotFoundException(
            int id,
            string nome,
            string registro,
            double latitude,
            double longitude,
            int setorCensitario,
            long areaPonderacao,
            int codigoDistrito,
            string nomeDistrito,
            int codigoSubPrefeitura,
            string nomeSubPrefeitura,
            string regiaoDivisaoEm5Areas,
            string regiaoDivisaoEm8Areas,
            string logradouro,
            string numero,
            string bairro,
            string referencia)
        {
            // arrange
            var presenter = new UpdatePresenter();
            var useCase = new UseCase(
                Fixtures.FeiraLivreRepository,
                Fixtures.UnitOfWork,
                presenter);

            var inputData = new InputData(
                id,
                nome,
                registro,
                longitude,
                latitude,
                setorCensitario,
                areaPonderacao,
                codigoDistrito,
                nomeDistrito,
                codigoSubPrefeitura,
                nomeSubPrefeitura,
                regiaoDivisaoEm5Areas,
                regiaoDivisaoEm8Areas,
                logradouro,
                numero,
                bairro,
                referencia);

            // act
            // assert
            await Assert.ThrowsAsync<BusinessApplicationRecordNotFoundException>(
                () => useCase.RequestAsync(inputData));
        }
    }
}
