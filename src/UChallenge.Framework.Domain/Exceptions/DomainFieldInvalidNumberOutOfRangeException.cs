using UChallenge.Framework.Domain.Properties;

namespace UChallenge.Framework.Domain.Exceptions
{
    public sealed class DomainFieldInvalidNumberOutOfRangeException :
        DomainFieldException
    {
        public DomainFieldInvalidNumberOutOfRangeException(string fieldName, double minValue) :
            this(fieldName, minValue, double.MaxValue)
        {
        }

        public DomainFieldInvalidNumberOutOfRangeException(string fieldName, double minValue, double maxValue) :
            base(string.Format(Resources.Field_Invalid_Number_OutOfRange, fieldName, minValue, maxValue))
        {
        }
    }
}
