using System.Text.RegularExpressions;
using UChallenge.Domain.Properties;
using UChallenge.Framework.Domain.Exceptions;
using UChallenge.Framework.Domain.Models;
using UChallenge.Framework.Domain.ValueObjects;

namespace UChallenge.Domain.FeiraLivreAggregates
{
    public abstract record FeiraLivre :
        BaseEntity<int>
    {
        public string Nome { get; private set; }
        public string Registro { get; private set; }
        public Longitude Longitude { get; private set; }
        public Latitude Latitude { get; private set; }
        public int SetorCensitario { get; private set; }
        public long AreaPonderacao { get; private set; }
        public int CodigoDistrito { get; private set; }
        public string NomeDistrito { get; private set; }
        public int CodigoSubPrefeitura { get; private set; }
        public string NomeSubPrefeitura { get; private set; }
        public string RegiaoDivisaoEm5Areas { get; private set; }
        public string RegiaoDivisaoEm8Areas { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Referencia { get; private set; }

        protected FeiraLivre(
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
            ValidateId(id);

            Id = id;
            SetLongitude(longitude);
            SetLatitude(latitude);
            SetSetorCensitario(setorCensitario);
            SetAreaPonderacao(areaPonderacao);
            SetCodigoDistrito(codigoDistrito);
            SetNomeDistrito(nomeDistrito);
            SetCodigoSubPrefeitura(codigoSubPrefeitura);
            SetNomeSubPrefeitura(nomeSubPrefeitura);
            SetRegiaoDivisaoEm5Areas(regiaoDivisaoEm5Areas);
            SetRegiaoDivisaoEm8Areas(regiaoDivisaoEm8Areas);
            Setnome(nome);
            Setregistro(registro);
            SetLogradouro(logradouro);
            SetNumero(numero);
            SetBairro(bairro);
            SetReferencia(referencia);
        }

      
        public void UpdateProperties(
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
            Setnome(nome);
            Setregistro(registro);
            SetLogradouro(logradouro);
            SetNumero(numero);
            SetBairro(bairro);
            SetReferencia(referencia);
            SetCodigoDistrito(codigoDistrito);
            SetNomeDistrito(nomeDistrito);
            SetLongitude(longitude);
            SetLatitude(latitude);
            SetSetorCensitario(setorCensitario);
            SetAreaPonderacao(areaPonderacao);
            SetCodigoSubPrefeitura(codigoSubPrefeitura);
            SetNomeSubPrefeitura(nomeSubPrefeitura);
            SetRegiaoDivisaoEm5Areas(regiaoDivisaoEm5Areas);
            SetRegiaoDivisaoEm8Areas(regiaoDivisaoEm8Areas);
        }

        private static void ValidateId(int id)
        {
            if (id <= 0)
                throw new DomainFieldRequiredNumberException(Resources.FeiraLivre_Id);
        }

        private void Setnome(string nome)
        {
            var nomeLength = nome.Trim().Length;

            if (string.IsNullOrWhiteSpace(nome))
                throw new DomainFieldRequiredException(Resources.FeiraLivre_nome);
            else if (nomeLength < 1 || nomeLength > 30)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_nome, 1, 30);

            Nome = nome;
        }

        private void Setregistro(string registro)
        {
            var registroLength = registro.Trim().Length;

            if (string.IsNullOrWhiteSpace(registro))
                throw new DomainFieldRequiredException(Resources.FeiraLivre_registro);
            else if (registroLength < 1 || registroLength > 6)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_registro, 1, 6);

            Registro = registro;
        }

        private void SetLongitude(Longitude longitude)
        {
            Longitude = longitude;
        }

        private void SetLatitude(Latitude latitude)
        {
            Latitude = latitude;
        }

        private void SetSetorCensitario(int setorCensitario)
        {
            if (setorCensitario <= 0)
                throw new DomainFieldRequiredNumberException(Resources.FeiraLivre_SetorCensitario);

            SetorCensitario = setorCensitario;
        }

        private void SetAreaPonderacao(long areaPonderacao)
        {
            if (areaPonderacao <= 0)
                throw new DomainFieldRequiredNumberException(Resources.FeiraLivre_AreaPonderacao);

            AreaPonderacao = areaPonderacao;
        }

        private void SetCodigoDistrito(int codigoDistrito)
        {
            if (codigoDistrito <= 0)
                throw new DomainFieldRequiredNumberException(Resources.FeiraLivre_CodigoDistrito);

            CodigoDistrito = codigoDistrito;
        }

        private void SetNomeDistrito(string nomeDistrito)
        {
            var nomeDistritoLength = nomeDistrito.Trim().Length;

            if (string.IsNullOrWhiteSpace(nomeDistrito))
                throw new DomainFieldRequiredException(Resources.FeiraLivre_NomeDistrito);
            else if (nomeDistritoLength < 1 || nomeDistritoLength > 18)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_NomeDistrito, 1, 18);

            NomeDistrito = nomeDistrito;
        }

        private void SetCodigoSubPrefeitura(int codigoSubPrefeitura)
        {
            if (codigoSubPrefeitura <= 0)
                throw new DomainFieldRequiredNumberException(Resources.FeiraLivre_CodigoSubPrefeitura);

            CodigoSubPrefeitura = codigoSubPrefeitura;
        }

        private void SetNomeSubPrefeitura(string nomeSubPrefeitura)
        {
            var nomeSubPrefeituraLength = nomeSubPrefeitura.Trim().Length;

            if (string.IsNullOrWhiteSpace(nomeSubPrefeitura))
                throw new DomainFieldRequiredException(Resources.FeiraLivre_NomeSubPrefeitura);
            else if (nomeSubPrefeituraLength < 1 || nomeSubPrefeituraLength > 25)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_NomeSubPrefeitura, 1, 25);

            NomeSubPrefeitura = nomeSubPrefeitura;
        }

        private void SetRegiaoDivisaoEm5Areas(string regiaoDivisaoEm5Areas)
        {
            var regiaoDivisaoEm5AreasLength = regiaoDivisaoEm5Areas.Trim().Length;

            if (string.IsNullOrWhiteSpace(regiaoDivisaoEm5Areas))
                throw new DomainFieldRequiredException(Resources.FeiraLivre_RegiaoDivisaoEm5Areas);
            else if (regiaoDivisaoEm5AreasLength < 1 || regiaoDivisaoEm5AreasLength > 6)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_RegiaoDivisaoEm5Areas, 1, 6);

            RegiaoDivisaoEm5Areas = regiaoDivisaoEm5Areas;
        }

        private void SetRegiaoDivisaoEm8Areas(string regiaoDivisaoEm8Areas)
        {
            var regiaoDivisaoEm8AreasLength = regiaoDivisaoEm8Areas.Trim().Length;

            if (string.IsNullOrWhiteSpace(regiaoDivisaoEm8Areas))
                throw new DomainFieldRequiredException(Resources.FeiraLivre_RegiaoDivisaoEm8Areas);
            else if (regiaoDivisaoEm8AreasLength < 1 || regiaoDivisaoEm8AreasLength > 7)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_RegiaoDivisaoEm8Areas, 1, 7);

            RegiaoDivisaoEm8Areas = regiaoDivisaoEm8Areas;
        }

        private void SetLogradouro(string logradouro)
        {
            var logradouroLength = logradouro.Trim().Length;

            if (string.IsNullOrWhiteSpace(logradouro))
                throw new DomainFieldRequiredException(Resources.FeiraLivre_Logradouro);
            else if (logradouroLength < 1 && logradouroLength > 34)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_Logradouro, 1, 34);

            Logradouro = logradouro;
        }

        private void SetNumero(string numero)
        {
            var normalizedNumero = Regex.Replace(numero, "[^0-9]", "");
            if (string.IsNullOrWhiteSpace(normalizedNumero))
                normalizedNumero = "S/N";

            var numeroLength = normalizedNumero.Trim().Length;
            if (numeroLength < 0 && numeroLength > 5)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_Numero, 1, 5);

            Numero = normalizedNumero.ToUpper();
        }

        private void SetBairro(string bairro)
        {
            var bairroLength = bairro?.Trim().Length;
            if (bairroLength < 1 && bairroLength > 34)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_Bairro, 1, 20);

            Bairro = bairro;
        }

        private void SetReferencia(string referencia)
        {
            var referenciaLength = referencia?.Trim().Length;
            if (referenciaLength > 30)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_Referencia, 0, 30);

            Referencia = referencia;
        }

    }
}

