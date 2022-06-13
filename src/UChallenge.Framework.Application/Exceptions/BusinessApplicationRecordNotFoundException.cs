using UChallenge.Framework.Application.Properties;

namespace UChallenge.Framework.Application.Exceptions
{
    public sealed class BusinessApplicationRecordNotFoundException :
        BusinessApplicationException
    {
        public readonly object Value;

        public BusinessApplicationRecordNotFoundException(object value) :
            this(string.Empty, value)
        {

        }

        public BusinessApplicationRecordNotFoundException(string entityName, object value) :
            base(string.Format(Resources.Record_DoesNotExists, entityName, value))
        {
            Value = value;
        }
    }
}
