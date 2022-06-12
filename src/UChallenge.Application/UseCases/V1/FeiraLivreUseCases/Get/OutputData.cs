using System.Collections.Generic;
using UChallenge.Framework.Application.UseCases;

namespace UChallenge.Application.UseCases.V1.FeiraLivreUseCases.Get
{
    public sealed record OutputData :
        IOutputData
    {
        public readonly IEnumerable<OutputDataItem> Items;

        public OutputData(IEnumerable<OutputDataItem> items)
        {
            Items = items;
        }
    }
}
