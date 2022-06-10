using UChallenge.Domain.Tests.Fixtures;
using UChallenge.Framework.Domain.Exceptions;
using UChallenge.Framework.Domain.ValueObjects;
using UChallenge.Framework.Tests.Fixtures;
using UChallenge.MockDB.FeiraLivreAggregates;
using Xunit;

namespace UChallenge.Domain.Tests.UnitTests.FeiraLivreTests
{
    public sealed class FeiraLivreUnitTests :
        BaseUnitTests<V1Fixtures>
    {
        public FeiraLivreUnitTests(V1Fixtures fixtures) :
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
            long id,
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
            var feiraLivre = new FeiraLivre(
                id,
                nomeFeira,
                registroFeira,
                new Longitude(longitude),
                new Latitude(latitude),
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
            Fixtures.FeiraLivreVLFORMOSA.Alterar(
                nomeFeira,
                registroFeira,
                new Longitude(longitude),
                new Latitude(latitude),
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

            // assert
            Assert.Equal(nomeFeira, Fixtures.FeiraLivreVLFORMOSA.NomeFeira);
        }

        [Theory]
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
            long id,
            string nomeFeira,
            string registroFeira,
            double latitude,
            double longitude,
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

            // assert
            Assert.ThrowsAny<DomainException>(() => new FeiraLivre(
                id,
                nomeFeira,
                registroFeira,
                new Longitude(longitude),
                new Latitude(latitude),
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
            string nomeFeira,
            string registroFeira,
            double latitude,
            double longitude,
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

            // assert
            Assert.ThrowsAny<DomainException>(() => Fixtures.FeiraLivreVLFORMOSA.Alterar(
                nomeFeira,
                registroFeira,
                new Longitude(longitude),
                new Latitude(latitude),
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
                referencia));
        }
    }
}
