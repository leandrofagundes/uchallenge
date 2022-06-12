using System.Threading.Tasks;
using UChallenge.Application.Tests.Fixtures;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Create;
using UChallenge.Framework.Application.Exceptions;
using UChallenge.Framework.Domain.Exceptions;
using UChallenge.Framework.Tests.Fixtures;
using Xunit;

namespace UChallenge.Application.Tests.UseCases.V1.FeiraLivreIntegrationTests
{
    public sealed class CreateTests :
        BaseIntegrationTests<V1Fixtures>
    {
        public CreateTests(V1Fixtures fixtures) :
            base(fixtures)
        {
        }

        [Theory]
        [InlineData(2, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(3, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "", "referencia")]
        [InlineData(4, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "")]
        [InlineData(6, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "", "")]
        [InlineData(7, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "", "bairro", "referencia")]
        public async Task Create_FeiraLivreUseCase_ShouldSuccess(
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
            var presenter = new CreatePresenter();
            var useCase = new UseCase(
                Fixtures.FeiraLivreFactory,
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

        }

        [Theory]
        //[InlineData(0, "Nome", "R1234", -25.234, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        //[InlineData(10, "", "R1234", -25.234, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        //[InlineData(10, "Nome", "", -25.234, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "Nome", "Registro", -91, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "Nome", "Registro", 91, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "Nome", "Registro", -25.123, 181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "Nome", "Registro", -25.123, -181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        //[InlineData(10, "Nome", "Registro", -25.123, -25.181, 0, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        //[InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 0, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        //[InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 1, 0, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        //[InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        //[InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 0, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        //[InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        //[InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        //[InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "", "Rua logradouro", "1", "bairro", "referencia")]
        //[InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "", "1", "bairro", "referencia")]
        public async Task Create_FeiraLivreUseCase_ShouldThrows_InvalidInputDataException(
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
            var presenter = new CreatePresenter();
            var useCase = new UseCase(
                Fixtures.FeiraLivreFactory,
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
        [InlineData(0, "Nome", "R1234", -25.234, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "", "R1234", -25.234, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "Nome", "", -25.234, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "Nome", "Registro", -25.123, -25.181, 0, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 0, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 1, 0, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 0, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(10, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "", "1", "bairro", "referencia")]
        public async Task Create_FeiraLivreUseCase_ShouldThrows_DomainFieldException(
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
            var presenter = new CreatePresenter();
            var useCase = new UseCase(
                Fixtures.FeiraLivreFactory,
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
            await Assert.ThrowsAsync<DomainFieldException>(
                () => useCase.RequestAsync(inputData));
        }

        [Theory]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(5, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "", "bairro", "referencia")]
        public async Task Create_FeiraLivreUseCase_ShouldThrows_DuplicatedDataException(
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
            var presenter = new CreatePresenter();
            var useCase = new UseCase(
                Fixtures.FeiraLivreFactory,
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
            await Assert.ThrowsAsync<BusinessApplicationDuplicateDataException>(
                () => useCase.RequestAsync(inputData));
        }
    }
}
