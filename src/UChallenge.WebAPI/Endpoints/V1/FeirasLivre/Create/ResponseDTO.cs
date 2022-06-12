using UChallenge.Framework.WebAPI.Endpoints;

namespace UChallenge.WebAPI.Endpoints.V1.FeirasLivre.Create
{
    public sealed record ResponseDTO :
        IResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Registro { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int SetorCensitario { get; set; }
        public long AreaPonderacao { get; set; }
        public int CodigoDistrito { get; set; }
        public string NomeDistrito { get; set; }
        public int CodigoSubPrefeitura { get; set; }
        public string NomeSubPrefeitura { get; set; }
        public string RegiaoDivisaoEm5Areas { get; set; }
        public string RegiaoDivisaoEm8Areas { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Referencia { get; set; }
    }
}
