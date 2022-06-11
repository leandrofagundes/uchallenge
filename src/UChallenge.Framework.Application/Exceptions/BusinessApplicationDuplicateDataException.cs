using UChallenge.Framework.Application.Properties;

namespace UChallenge.Framework.Application.Exceptions
{
    public sealed class BusinessApplicationDuplicateDataException :
        BusinessApplicationException
    {
        public BusinessApplicationDuplicateDataException(string model, object value) :
            base(string.Format(Resources.Record_AlreadyExists, model, value))
        {

        }
    }
}
