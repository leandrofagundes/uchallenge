using UChallenge.Domain.Tests.Fixtures;
using UChallenge.Framework.Domain.Exceptions;
using UChallenge.Framework.Domain.ValueObjects;
using UChallenge.Framework.Tests.Fixtures;
using Xunit;

namespace UChallenge.Domain.Tests.UnitTests.FeiraLivreTests
{
    public sealed class FeiraLivreUnitTests :
        BaseUnitTests<DomainFixtures>
    {
        public FeiraLivreUnitTests(Fixtures.DomainFixtures fixtures) :
            base(fixtures)
        {
        }

        [Theory]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "", "")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "", "bairro", "referencia")]
        public void Create_FeiraLivre_ShouldSuccess(
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
            var feiraLivre = Fixtures.FeiraLivreFactory.Create(
                id,
                nome,
                registro,
                new Longitude(longitude),
                new Latitude(latitude),
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

            // assert
            Assert.NotNull(feiraLivre);
        }

        [Theory]
        [InlineData("Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "", "referencia")]
        [InlineData("Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "")]
        [InlineData("Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "", "")]
        [InlineData("Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "", "bairro", "referencia")]
        public void Update_FeiraLivre_ShouldSuccess(
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
            Fixtures.FeiraLivreVLFORMOSA.UpdateProperties(
                nome,
                registro,
                new Longitude(longitude),
                new Latitude(latitude),
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

            // assert
            Assert.Equal(nome, Fixtures.FeiraLivreVLFORMOSA.Nome);
        }

        [Theory]
        [InlineData(0, "Nome", "R1234", -25.234, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "", "R1234", -25.234, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "", -25.234, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -91, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", 91, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, 181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 0, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 0, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 0, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 0, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData(1, "Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "", "1", "bairro", "referencia")]
        public void Create_FeiraLivre_InvalidData_ShouldThrowsException(
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

            // assert
            Assert.ThrowsAny<DomainException>(() => Fixtures.FeiraLivreFactory.Create(
                id,
                nome,
                registro,
                new Longitude(longitude),
                new Latitude(latitude),
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
                referencia));
        }

        [Theory]
        [InlineData("", "R1234", -25.234, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "", -25.234, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "Registro", -91, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "Registro", 91, -25.543, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "Registro", -25.123, 181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "Registro", -25.123, -181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "Registro", -25.123, -25.181, 0, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "Registro", -25.123, -25.181, 1, 0, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "Registro", -25.123, -25.181, 1, 1, 0, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "Registro", -25.123, -25.181, 1, 1, 1, "", 1, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 0, "subprefeitura", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "", "regiao5", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "", "regiao8", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "", "Rua logradouro", "1", "bairro", "referencia")]
        [InlineData("Nome", "Registro", -25.123, -25.181, 1, 1, 1, "distrito", 1, "subprefeitura", "regiao5", "regiao8", "", "1", "bairro", "referencia")]
        public void Update_FeiraLivre_InvalidData_ShouldThrowsException(
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

            // assert
            Assert.ThrowsAny<DomainException>(() => Fixtures.FeiraLivreVLFORMOSA.UpdateProperties(
                nome,
                registro,
                new Longitude(longitude),
                new Latitude(latitude),
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
                referencia));
        }
    }
}
