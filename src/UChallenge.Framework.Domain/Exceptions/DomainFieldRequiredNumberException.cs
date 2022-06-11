using UChallenge.Framework.Domain.Properties;

namespace UChallenge.Framework.Domain.Exceptions
{
    public sealed class DomainFieldRequiredNumberException :
        DomainFieldException
    {
        public DomainFieldRequiredNumberException(string fieldName) :
            base(string.Format(Resources.Field_IsRequired_Number_MustBeGreatherThenZero, fieldName))
        {

        }
    }
}
