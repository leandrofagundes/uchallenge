using System;
using System.Text.RegularExpressions;
using UChallenge.Domain.Properties;
using UChallenge.Framework.Domain.Models;
using UChallenge.Framework.Domain.ValueObjects;

namespace UChallenge.Domain.FeiraLivreAggregates
{
    public abstract record FeiraLivre :
        BaseEntity<long>
    {
        public string NomeFeira { get; private set; }
        public string RegistroFeira { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Referencia { get; private set; }
        public long CodigoDistrito { get; private set; }
        public string NomeDistrito { get; private set; }
        public Longitude Longitude { get; private set; }
        public Latitude Latitude { get; private set; }
        public int SetorCensitario { get; private set; }
        public long AreaDePonderacao { get; private set; }
        public int CodigoSubPrefeitura { get; private set; }
        public string NomeSubPrefeitura { get; private set; }
        public string RegiaoPorDivisaoEm5Areas { get; private set; }
        public string RegiaoPorDivisaoEm8Areas { get; private set; }

        protected FeiraLivre(
            long id,
            string nomeFeira,
            string registroFeira,
            string logradouro,
            string numero,
            string bairro,
            string referencia,
            long codigoDistrito,
            string nomeDistrito,
            Longitude longitude,
            Latitude latitude,
            int setorCensitario,
            long areaDePonderacao,
            int codigoSubPrefeitura,
            string nomeSubPrefeitura,
            string regiaoPorDivisaoEm5Areas,
            string regiaoPorDivisaoEm8Areas)
        {
            Id = id;
            Longitude = longitude;
            Latitude = latitude;
            SetorCensitario = setorCensitario;
            AreaDePonderacao = areaDePonderacao;
            CodigoDistrito = codigoDistrito;
            NomeDistrito = nomeDistrito;
            CodigoSubPrefeitura = codigoSubPrefeitura;
            NomeSubPrefeitura = nomeSubPrefeitura;
            RegiaoPorDivisaoEm5Areas = regiaoPorDivisaoEm5Areas;
            RegiaoPorDivisaoEm8Areas = regiaoPorDivisaoEm8Areas;
            NomeFeira = nomeFeira;
            RegistroFeira = registroFeira;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Referencia = referencia;
        }

        public void Alterar(string nomeFeira,
            string registroFeira,
            string logradouro,
            string numero,
            string bairro,
            string referencia,
            long codigoDistrito,
            string nomeDistrito,
            double longitude,
            double latitude,
            int setorCensitario,
            long areaDePonderacao,
            int codigoSubPrefeitura,
            string nomeSubPrefeitura,
            string regiaoPorDivisaoEm5Areas,
            string regiaoPorDivisaoEm8Areas)
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
                throw new ArgumentNullException(nameof(NomeFeira), string.Format(Resources.Field_IsRequired, Resources.FeiraLivre_NomeFeira));
            else if (nomeFeiraLength < 1 && nomeFeiraLength > 30)
                throw new ArgumentOutOfRangeException(nameof(NomeFeira), string.Format(Resources.Field_InvalidLength, Resources.FeiraLivre_NomeFeira, 1, 30));

            NomeFeira = nomeFeira;
        }

        public void SetRegistroFeira(string registroFeira)
        {
            var registroFeiraLength = registroFeira.Trim().Length;

            if (string.IsNullOrWhiteSpace(registroFeira))
                throw new ArgumentNullException(nameof(RegistroFeira), string.Format(Resources.Field_IsRequired, Resources.FeiraLivre_RegistroFeira));
            else if (registroFeiraLength < 1 && registroFeiraLength > 6)
                throw new ArgumentOutOfRangeException(nameof(RegistroFeira), string.Format(Resources.Field_InvalidLength, Resources.FeiraLivre_RegistroFeira, 1, 6));

            RegistroFeira = registroFeira;
        }

        public void SetLogradouro(string logradouro)
        {
            var logradouroLength = logradouro.Trim().Length;

            if (string.IsNullOrWhiteSpace(logradouro))
                throw new ArgumentNullException(nameof(Logradouro), string.Format(Resources.Field_IsRequired, Resources.FeiraLivre_Logradouro));
            else if (logradouroLength < 1 && logradouroLength > 34)
                throw new ArgumentOutOfRangeException(nameof(Logradouro), string.Format(Resources.Field_InvalidLength, Resources.FeiraLivre_Logradouro, 1, 34));

            Logradouro = logradouro;
        }

        public void SetNumero(string numero)
        {
            var normalizedNumero = Regex.Replace(numero, "[^0-9]", "");
            if (string.IsNullOrWhiteSpace(normalizedNumero))
                normalizedNumero = "S/N";

            var numeroLength = normalizedNumero.Trim().Length;
            if (numeroLength < 0 && numeroLength > 5)
                throw new ArgumentOutOfRangeException(nameof(numero), string.Format(Resources.Field_InvalidLength, Resources.FeiraLivre_Numero, 1, 5));

            Numero = normalizedNumero.ToUpper();
        }

        public void SetBairro(string bairro)
        {
            var bairroLength = bairro.Trim().Length;
            if (bairroLength < 1 && bairroLength > 34)
                throw new ArgumentOutOfRangeException(nameof(Bairro), string.Format(Resources.Field_InvalidLength, Resources.FeiraLivre_Bairro, 1, 20));

            Bairro = bairro;
        }

        public void SetReferencia(string referencia)
        {
            var referenciaLength = referencia.Trim().Length;
            if (referenciaLength > 30)
                throw new ArgumentOutOfRangeException(nameof(Referencia), string.Format(Resources.Field_InvalidLength, Resources.FeiraLivre_Referencia, 0, 30));

            Referencia = referencia;
        }

        public void SetCodigoDistrito(long codigoDistrito)
        {
            if (codigoDistrito < 0)
                throw new ArgumentOutOfRangeException(nameof(CodigoDistrito), string.Format(Resources.Field_InvalidNumber_MustBeGreatherThenZero, Resources.FeiraLivre_CodigoDistrito));

            CodigoDistrito = codigoDistrito;
        }

        public void SetNomeDistrito(string nomeDistrito)
        {
            var nomeDistritoLength = nomeDistrito.Trim().Length;

            if (string.IsNullOrWhiteSpace(nomeDistrito))
                throw new ArgumentNullException(nameof(NomeDistrito), string.Format(Resources.Field_IsRequired, Resources.FeiraLivre_NomeDistrito));
            else if (nomeDistritoLength < 1 && nomeDistritoLength > 18)
                throw new ArgumentOutOfRangeException(nameof(NomeDistrito), string.Format(Resources.Field_InvalidLength, Resources.FeiraLivre_NomeDistrito, 1, 18));

            NomeDistrito = nomeDistrito;
        }

        public void SetLongitude(double longitude)
        {
            Longitude = new Longitude(longitude);
        }

        public void SetLatitude(double latitude)
        {
            Latitude = new Latitude(latitude);
        }

        public void SetSetorCensitario(int setorCensitario)
        {
            if (setorCensitario < 0)
                throw new ArgumentOutOfRangeException(nameof(SetorCensitario), string.Format(Resources.Field_InvalidNumber_MustBeGreatherThenZero, Resources.FeiraLivre_SetorCensitario));

            SetorCensitario = setorCensitario;
        }

        public void SetAreaDePonderacao(long areaDePonderacao)
        {
            if (areaDePonderacao < 0)
                throw new ArgumentOutOfRangeException(nameof(AreaDePonderacao), string.Format(Resources.Field_InvalidNumber_MustBeGreatherThenZero, Resources.FeiraLivre_AreaDePonderacao));

            AreaDePonderacao = areaDePonderacao;
        }

        public void SetCodigoSubPrefeitura(int codigoSubPrefeitura)
        {
            if (codigoSubPrefeitura < 0)
                throw new ArgumentOutOfRangeException(nameof(CodigoSubPrefeitura), string.Format(Resources.Field_InvalidNumber_MustBeGreatherThenZero, Resources.FeiraLivre_CodigoSubPrefeitura));

            CodigoSubPrefeitura = codigoSubPrefeitura;
        }

        public void SetNomeSubPrefeitura(string nomeSubPrefeitura)
        {
            var nomeSubPrefeituraLength = nomeSubPrefeitura.Trim().Length;

            if (string.IsNullOrWhiteSpace(nomeSubPrefeitura))
                throw new ArgumentNullException(nameof(NomeSubPrefeitura), string.Format(Resources.Field_IsRequired, Resources.FeiraLivre_NomeSubPrefeitura));
            else if (nomeSubPrefeituraLength < 1 && nomeSubPrefeituraLength > 25)
                throw new ArgumentOutOfRangeException(nameof(NomeSubPrefeitura), string.Format(Resources.Field_InvalidLength, Resources.FeiraLivre_NomeSubPrefeitura, 1, 25));

            NomeSubPrefeitura = nomeSubPrefeitura;
        }

        public void SetRegiaoPorDivisaoEm5Areas(string regiaoPorDivisaoEm5Areas)
        {
            var regiaoPorDivisaoEm5AreasLength = regiaoPorDivisaoEm5Areas.Trim().Length;

            if (string.IsNullOrWhiteSpace(regiaoPorDivisaoEm5Areas))
                throw new ArgumentNullException(nameof(RegiaoPorDivisaoEm5Areas), string.Format(Resources.Field_IsRequired, Resources.FeiraLivre_RegiaoPorDivisaoEm5Areas));
            else if (regiaoPorDivisaoEm5AreasLength < 1 && regiaoPorDivisaoEm5AreasLength > 6)
                throw new ArgumentOutOfRangeException(nameof(RegiaoPorDivisaoEm5Areas), string.Format(Resources.Field_InvalidLength, Resources.FeiraLivre_RegiaoPorDivisaoEm5Areas, 1, 6));

            RegiaoPorDivisaoEm5Areas = regiaoPorDivisaoEm5Areas;
        }

        public void SetRegiaoPorDivisaoEm8Areas(string regiaoPorDivisaoEm8Areas)
        {
            var regiaoPorDivisaoEm8AreasLength = regiaoPorDivisaoEm8Areas.Trim().Length;

            if (string.IsNullOrWhiteSpace(regiaoPorDivisaoEm8Areas))
                throw new ArgumentNullException(nameof(RegiaoPorDivisaoEm8Areas), string.Format(Resources.Field_IsRequired, Resources.FeiraLivre_RegiaoPorDivisaoEm8Areas));
            else if (regiaoPorDivisaoEm8AreasLength < 1 && regiaoPorDivisaoEm8AreasLength > 7)
                throw new ArgumentOutOfRangeException(nameof(RegiaoPorDivisaoEm8Areas), string.Format(Resources.Field_InvalidLength, Resources.FeiraLivre_RegiaoPorDivisaoEm8Areas, 1, 6));

            RegiaoPorDivisaoEm8Areas = regiaoPorDivisaoEm8Areas;
        }
    }
}

