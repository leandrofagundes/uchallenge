using System.Collections.Generic;

namespace UChallenge.Framework.Application.Exceptions
{
    public sealed class BusinessApplicationInvalidInputDataException :
        BusinessApplicationException
    {
        public Dictionary<string, string> Errors { get; }

        public BusinessApplicationInvalidInputDataException(Dictionary<string, string> errors) :
            base("")
        {
            Errors = errors;
        }
    }
}
