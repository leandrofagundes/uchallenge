using UChallenge.Framework.Domain.ValueObjects;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Get
{
    public sealed record OutputDataItem
    {
        public readonly int Id;
        public readonly string Nome;
        public readonly string Registro;
        public readonly Longitude Longitude;
        public readonly Latitude Latitude;
        public readonly int SetorCensitario;
        public readonly long AreaPonderacao;
        public readonly int CodigoDistrito;
        public readonly string NomeDistrito;
        public readonly int CodigoSubPrefeitura;
        public readonly string NomeSubPrefeitura;
        public readonly string RegiaoDivisaoEm5Areas;
        public readonly string RegiaoDivisaoEm8Areas;
        public readonly string Logradouro;
        public readonly string Numero;
        public readonly string Bairro;
        public readonly string Referencia;

        public OutputDataItem(
            int id,
            string nome,
            string registro,
            Longitude longitude,
            Latitude latitude,
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
            Id = id;
            Nome = nome;
            Registro = registro;
            Latitude = latitude;
            Longitude = longitude;
            SetorCensitario = setorCensitario;
            AreaPonderacao = areaPonderacao;
            CodigoDistrito = codigoDistrito;
            NomeDistrito = nomeDistrito;
            CodigoSubPrefeitura = codigoSubPrefeitura;
            NomeSubPrefeitura = nomeSubPrefeitura;
            RegiaoDivisaoEm5Areas = regiaoDivisaoEm5Areas;
            RegiaoDivisaoEm8Areas = regiaoDivisaoEm8Areas;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Referencia = referencia;
        }
    }
}
