using System.Threading.Tasks;
using UChallenge.Application.Tests.Fixtures;
using UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Create;
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
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(2, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "", "referencia")]
        [InlineData(3, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "")]
        [InlineData(4, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "", "")]
        [InlineData(5, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "", "bairro", "referencia")]
        public async Task Create_ShouldSuccess(long id,
            string nomeFeira,
            string registroFeira,
            double longitude,
            double latitude,
            long setorCensitario,
            long areaDePonderacao,
            int codigoDistrito,
            string nomeDistrito,
            int codigoSubPrefeitura,
            string nomeSubPrefeitura,
            string regiaoPorDivisaoEm5Areas,
            string regiaoPorDivisaoEm8Areas,
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
                nomeFeira,
                registroFeira,
                longitude,
                latitude,
                setorCensitario,
                areaDePonderacao,
                codigoDistrito,
                nomeDistrito,
                codigoSubPrefeitura,
                nomeSubPrefeitura,
                regiaoPorDivisaoEm5Areas,
                regiaoPorDivisaoEm8Areas,
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
    }
}
