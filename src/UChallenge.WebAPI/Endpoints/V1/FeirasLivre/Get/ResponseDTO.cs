using System.Collections.Generic;
using UChallenge.Framework.WebAPI.Endpoints;

namespace UChallenge.WebAPI.Endpoints.V1.FeirasLivre.Get
{
    /// <summary>
    /// Response Data Transfer Object from fetching records of Feira Livre.
    /// </summary>
    public sealed record ResponseDTO :
        IResponseDTO
    {
        /// <summary>
        /// A list of items matched by the request.
        /// </summary>
        public IEnumerable<ResponseDTOItem> Items { get; set; }
    }
}
