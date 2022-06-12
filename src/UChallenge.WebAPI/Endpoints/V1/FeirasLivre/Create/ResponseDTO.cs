using UChallenge.Framework.WebAPI.Endpoints;

namespace UChallenge.WebAPI.Endpoints.V1.FeirasLivre.Create
{
    public sealed record ResponseDTO :
        IResponseDTO
    {
        public long Id { get; set; }
        public string NomeFeira { get; set; }
        public string RegistroFeira { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public long SetorCensitario { get; set; }
        public long AreaDePonderacao { get; set; }
        public int CodigoDistrito { get; set; }
        public string NomeDistrito { get; set; }
        public int CodigoSubPrefeitura { get; set; }
        public string NomeSubPrefeitura { get; set; }
        public string RegiaoPorDivisaoEm5Areas { get; set; }
        public string RegiaoPorDivisaoEm8Areas { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Referencia { get; set; }
    }
}
