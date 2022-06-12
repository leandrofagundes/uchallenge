using UChallenge.Framework.Application.UseCases;
using UChallenge.Framework.Domain.Exceptions;
using UChallenge.Framework.Domain.ValueObjects;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Update
{
    public sealed record InputData :
        BaseInputData
    {
        public readonly long Id;
        public readonly string NomeFeira;
        public readonly string RegistroFeira;
        public readonly Longitude Longitude;
        public readonly Latitude Latitude;
        public readonly long SetorCensitario;
        public readonly long AreaDePonderacao;
        public readonly int CodigoDistrito;
        public readonly string NomeDistrito;
        public readonly int CodigoSubPrefeitura;
        public readonly string NomeSubPrefeitura;
        public readonly string RegiaoPorDivisaoEm5Areas;
        public readonly string RegiaoPorDivisaoEm8Areas;
        public readonly string Logradouro;
        public readonly string Numero;
        public readonly string Bairro;
        public readonly string Referencia;

        public InputData(
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
            Id = id;
            NomeFeira = nomeFeira;
            RegistroFeira = registroFeira;

            try
            {
                Latitude = new(latitude);
            }
            catch (DomainFieldException fieldEx)
            {
                AddInvalidData(nameof(Latitude), fieldEx.Message);
            }

            try
            {
                Longitude = new(longitude);
            }
            catch (DomainFieldException fieldEx)
            {
                AddInvalidData(nameof(Longitude), fieldEx.Message);
            }


            SetorCensitario = setorCensitario;
            AreaDePonderacao = areaDePonderacao;
            CodigoDistrito = codigoDistrito;
            NomeDistrito = nomeDistrito;
            CodigoSubPrefeitura = codigoSubPrefeitura;
            NomeSubPrefeitura = nomeSubPrefeitura;
            RegiaoPorDivisaoEm5Areas = regiaoPorDivisaoEm5Areas;
            RegiaoPorDivisaoEm8Areas = regiaoPorDivisaoEm8Areas;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Referencia = referencia;
        }
    }
}
