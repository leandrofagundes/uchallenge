using UChallenge.Framework.Domain.Properties;

namespace UChallenge.Framework.Domain.Exceptions
{
    public sealed class DomainFieldInvalidLengthException :
        DomainFieldException
    {
        public DomainFieldInvalidLengthException(string fieldName, int minLength, int maxLength) :
            base(string.Format(Resources.Field_InvalidLength, fieldName, minLength, maxLength))
        {

        }
    }
}
