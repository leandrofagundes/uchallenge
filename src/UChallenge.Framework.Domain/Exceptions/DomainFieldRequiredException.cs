using UChallenge.Framework.Domain.Properties;

namespace UChallenge.Framework.Domain.Exceptions
{
    public sealed class DomainFieldRequiredException :
        DomainFieldException
    {
        public DomainFieldRequiredException(string fieldName) :
            base(string.Format(Resources.Field_IsRequired, fieldName))
        {

        }
    }
}
