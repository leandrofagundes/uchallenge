using System;
using System.Text.RegularExpressions;
using UChallenge.Domain.Properties;
using UChallenge.Framework.Domain.Exceptions;
using UChallenge.Framework.Domain.Models;
using UChallenge.Framework.Domain.ValueObjects;

namespace UChallenge.Domain.FeiraLivreAggregates
{
    public abstract record FeiraLivre :
        BaseEntity<long>
    {
        public string NomeFeira { get; private set; }
        public string RegistroFeira { get; private set; }
        public Longitude Longitude { get; private set; }
        public Latitude Latitude { get; private set; }
        public long SetorCensitario { get; private set; }
        public long AreaDePonderacao { get; private set; }
        public int CodigoDistrito { get; private set; }
        public string NomeDistrito { get; private set; }
        public int CodigoSubPrefeitura { get; private set; }
        public string NomeSubPrefeitura { get; private set; }
        public string RegiaoPorDivisaoEm5Areas { get; private set; }
        public string RegiaoPorDivisaoEm8Areas { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Referencia { get; private set; }

        protected FeiraLivre(
            long id,
            string nomeFeira,
            string registroFeira,
            Longitude longitude,
            Latitude latitude,
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
            ValidateId(id);

            Id = id;
            SetLongitude(longitude);
            SetLatitude(latitude);
            SetSetorCensitario(setorCensitario);
            SetAreaDePonderacao(areaDePonderacao);
            SetCodigoDistrito(codigoDistrito);
            SetNomeDistrito(nomeDistrito);
            SetCodigoSubPrefeitura(codigoSubPrefeitura);
            SetNomeSubPrefeitura(nomeSubPrefeitura);
            SetRegiaoPorDivisaoEm5Areas(regiaoPorDivisaoEm5Areas);
            SetRegiaoPorDivisaoEm8Areas(regiaoPorDivisaoEm8Areas);
            SetNomeFeira(nomeFeira);
            SetRegistroFeira(registroFeira);
            SetLogradouro(logradouro);
            SetNumero(numero);
            SetBairro(bairro);
            SetReferencia(referencia);
        }

        private void ValidateId(long id)
        {
            if (id <= 0)
                throw new DomainFieldRequiredNumberException(Resources.FeiraLivre_Id);
        }

        public void UpdateProperties(
            string nomeFeira,
            string registroFeira,
            Longitude longitude,
            Latitude latitude,
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
            SetNomeFeira(nomeFeira);
            SetRegistroFeira(registroFeira);
            SetLogradouro(logradouro);
            SetNumero(numero);
            SetBairro(bairro);
            SetReferencia(referencia);
            SetCodigoDistrito(codigoDistrito);
            SetNomeDistrito(nomeDistrito);
            SetLongitude(longitude);
            SetLatitude(latitude);
            SetSetorCensitario(setorCensitario);
            SetAreaDePonderacao(areaDePonderacao);
            SetCodigoSubPrefeitura(codigoSubPrefeitura);
            SetNomeSubPrefeitura(nomeSubPrefeitura);
            SetRegiaoPorDivisaoEm5Areas(regiaoPorDivisaoEm5Areas);
            SetRegiaoPorDivisaoEm8Areas(regiaoPorDivisaoEm8Areas);
        }

        public void SetNomeFeira(string nomeFeira)
        {
            var nomeFeiraLength = nomeFeira.Trim().Length;

            if (string.IsNullOrWhiteSpace(nomeFeira))
                throw new DomainFieldRequiredException(Resources.FeiraLivre_NomeFeira);
            else if (nomeFeiraLength < 1 && nomeFeiraLength > 30)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_NomeFeira, 1, 30);

            NomeFeira = nomeFeira;
        }

        public void SetRegistroFeira(string registroFeira)
        {
            var registroFeiraLength = registroFeira.Trim().Length;

            if (string.IsNullOrWhiteSpace(registroFeira))
                throw new DomainFieldRequiredException(Resources.FeiraLivre_RegistroFeira);
            else if (registroFeiraLength < 1 && registroFeiraLength > 6)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_RegistroFeira, 1, 6);

            RegistroFeira = registroFeira;
        }

        public void SetLongitude(Longitude longitude)
        {
            Longitude = longitude;
        }

        public void SetLatitude(Latitude latitude)
        {
            Latitude = latitude;
        }

        public void SetSetorCensitario(long setorCensitario)
        {
            if (setorCensitario <= 0)
                throw new DomainFieldRequiredNumberException(Resources.FeiraLivre_SetorCensitario);

            SetorCensitario = setorCensitario;
        }

        public void SetAreaDePonderacao(long areaDePonderacao)
        {
            if (areaDePonderacao <= 0)
                throw new DomainFieldRequiredNumberException(Resources.FeiraLivre_AreaDePonderacao);

            AreaDePonderacao = areaDePonderacao;
        }

        public void SetCodigoDistrito(int codigoDistrito)
        {
            if (codigoDistrito <= 0)
                throw new DomainFieldRequiredNumberException(Resources.FeiraLivre_CodigoDistrito);

            CodigoDistrito = codigoDistrito;
        }

        public void SetNomeDistrito(string nomeDistrito)
        {
            var nomeDistritoLength = nomeDistrito.Trim().Length;

            if (string.IsNullOrWhiteSpace(nomeDistrito))
                throw new DomainFieldRequiredException(Resources.FeiraLivre_NomeDistrito);
            else if (nomeDistritoLength < 1 && nomeDistritoLength > 18)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_NomeDistrito, 1, 18);

            NomeDistrito = nomeDistrito;
        }

        public void SetCodigoSubPrefeitura(int codigoSubPrefeitura)
        {
            if (codigoSubPrefeitura <= 0)
                throw new DomainFieldRequiredNumberException(Resources.FeiraLivre_CodigoSubPrefeitura);

            CodigoSubPrefeitura = codigoSubPrefeitura;
        }

        public void SetNomeSubPrefeitura(string nomeSubPrefeitura)
        {
            var nomeSubPrefeituraLength = nomeSubPrefeitura.Trim().Length;

            if (string.IsNullOrWhiteSpace(nomeSubPrefeitura))
                throw new DomainFieldRequiredException(Resources.FeiraLivre_NomeSubPrefeitura);
            else if (nomeSubPrefeituraLength < 1 && nomeSubPrefeituraLength > 25)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_NomeSubPrefeitura, 1, 25);

            NomeSubPrefeitura = nomeSubPrefeitura;
        }

        public void SetRegiaoPorDivisaoEm5Areas(string regiaoPorDivisaoEm5Areas)
        {
            var regiaoPorDivisaoEm5AreasLength = regiaoPorDivisaoEm5Areas.Trim().Length;

            if (string.IsNullOrWhiteSpace(regiaoPorDivisaoEm5Areas))
                throw new DomainFieldRequiredException(Resources.FeiraLivre_RegiaoPorDivisaoEm5Areas);
            else if (regiaoPorDivisaoEm5AreasLength < 1 && regiaoPorDivisaoEm5AreasLength > 6)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_RegiaoPorDivisaoEm5Areas, 1, 6);

            RegiaoPorDivisaoEm5Areas = regiaoPorDivisaoEm5Areas;
        }

        public void SetRegiaoPorDivisaoEm8Areas(string regiaoPorDivisaoEm8Areas)
        {
            var regiaoPorDivisaoEm8AreasLength = regiaoPorDivisaoEm8Areas.Trim().Length;

            if (string.IsNullOrWhiteSpace(regiaoPorDivisaoEm8Areas))
                throw new DomainFieldRequiredException(Resources.FeiraLivre_RegiaoPorDivisaoEm8Areas);
            else if (regiaoPorDivisaoEm8AreasLength < 1 && regiaoPorDivisaoEm8AreasLength > 7)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_RegiaoPorDivisaoEm8Areas, 1, 6);

            RegiaoPorDivisaoEm8Areas = regiaoPorDivisaoEm8Areas;
        }

        public void SetLogradouro(string logradouro)
        {
            var logradouroLength = logradouro.Trim().Length;

            if (string.IsNullOrWhiteSpace(logradouro))
                throw new DomainFieldRequiredException(Resources.FeiraLivre_Logradouro);
            else if (logradouroLength < 1 && logradouroLength > 34)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_Logradouro, 1, 34);

            Logradouro = logradouro;
        }

        public void SetNumero(string numero)
        {
            var normalizedNumero = Regex.Replace(numero, "[^0-9]", "");
            if (string.IsNullOrWhiteSpace(normalizedNumero))
                normalizedNumero = "S/N";

            var numeroLength = normalizedNumero.Trim().Length;
            if (numeroLength < 0 && numeroLength > 5)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_Numero, 1, 5);

            Numero = normalizedNumero.ToUpper();
        }

        public void SetBairro(string bairro)
        {
            var bairroLength = bairro.Trim().Length;
            if (bairroLength < 1 && bairroLength > 34)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_Bairro, 1, 20);

            Bairro = bairro;
        }

        public void SetReferencia(string referencia)
        {
            var referenciaLength = referencia.Trim().Length;
            if (referenciaLength > 30)
                throw new DomainFieldInvalidLengthException(Resources.FeiraLivre_Referencia, 0, 30);

            Referencia = referencia;
        }

    }
}

