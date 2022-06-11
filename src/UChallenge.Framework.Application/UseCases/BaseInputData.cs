using System.Collections.Generic;
using System.Linq;
using UChallenge.Framework.Application.Exceptions;

namespace UChallenge.Framework.Application.UseCases
{
    public abstract record BaseInputData
    {
        private readonly Dictionary<string, string> _invalidData;

        public BaseInputData()
        {
            _invalidData = new Dictionary<string, string>();
        }

        public void AddInvalidData(string propertyName, string message)
        {
            _invalidData[propertyName] = message;
        }

        private bool IsValid()
        {
            var hasInvalidData = _invalidData.Any();
            if (hasInvalidData)
                return false;
            else
                return true;
        }

        public Dictionary<string, string> GetErrors()
        {
            return new Dictionary<string, string>(_invalidData);
        }

        public void ThrowIfInvalidData()
        {
            if (!IsValid())
                throw new BusinessApplicationInvalidInputDataException(GetErrors());
        }
    }
}
