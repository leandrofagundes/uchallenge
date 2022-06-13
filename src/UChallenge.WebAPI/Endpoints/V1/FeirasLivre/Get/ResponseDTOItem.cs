using UChallenge.Framework.WebAPI.Endpoints;

namespace UChallenge.WebAPI.Endpoints.V1.FeirasLivre.Get
{
    /// <summary>
    /// Response Data Transfer Object from updated record of Feira Livre.
    /// </summary>
    public sealed record ResponseDTOItem
    {
        /// <summary>
        /// Identification number of the establishment georeferenced by SMDU/Deinfo,SMDU/Deinfo
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Denomination of the Feira Livre attributed by the Supply Supervision. Must be between 1 and 30 characters.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Registration number of the free fair at PMSP. Must be between 1 and 6 characters.
        /// </summary>
        public string Registro { get; set; }

        /// <summary>
        /// Longitude of the location of the establishment in the territory of the Municipality, according to MDC. The value is between -180 and 180.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Latitude of the location of the establishment in the territory of the Municipality, according to MDC. The value is between -90 and 90.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Census sector according to IBGE.
        /// </summary>
        public int SetorCensitario { get; set; }

        /// <summary>
        /// Weighting area (grouping of census sectors) according to IBGE 2010
        /// </summary>
        public long AreaPonderacao { get; set; }

        /// <summary>
        /// Municipal District Code according to IBGE. 
        /// </summary>
        public int CodigoDistrito { get; set; }

        /// <summary>
        /// Municipal District Name. Must be between 1 and 18 characters.
        /// </summary>
        public string NomeDistrito { get; set; }

        /// <summary>
        /// Code of each of the 31 Subprefectures (2003 to 2012)
        /// </summary>
        public int CodigoSubPrefeitura { get; set; }

        /// <summary>
        /// Subprefecture name (31 from 2003 to 2012). Must be between 1 and 25 characters.
        /// </summary>
        public string NomeSubPrefeitura { get; set; }

        /// <summary>
        /// Region according to the division of the Municipality into 5 areas. Must be between 1 and 6 characters.
        /// </summary>
        public string RegiaoDivisaoEm5Areas { get; set; }

        /// <summary>
        /// Region according to the division of the Municipality into 8 areas. Must be between 1 and 7 characters.
        /// </summary>
        public string RegiaoDivisaoEm8Areas { get; set; }

        /// <summary>
        /// Name of the street where the fair is located. Must be between 1 and 34 characters.
        /// </summary>
        public string Logradouro { get; set; }

        /// <summary>
        /// A number of the street where the fair is located. Must be between 1 and 5 numbers.
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Neighborhood of the fair's location. Must be between 0 and 20 characters 
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// Free fair location reference point. Must be between 0 and 30 characters 
        /// </summary>
        public string Referencia { get; set; }
    }
}
