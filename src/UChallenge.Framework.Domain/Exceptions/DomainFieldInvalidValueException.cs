using UChallenge.Framework.Domain.Properties;

namespace UChallenge.Framework.Domain.Exceptions
{
    public sealed class DomainFieldInvalidValueException :
        DomainFieldException
    {
        public DomainFieldInvalidValueException(string fieldName) :
            base(string.Format(Resources.Field_InvalidNumber_MustBeGreatherThenZero, fieldName))
        {

        }
    }
}
