using System.Collections.Generic;

namespace UChallenge.Framework.Application.UseCases
{
    public interface IOutputPortInvalidInputData
    {
        public void InvalidInputData(Dictionary<string, string> errors);
    }
}
