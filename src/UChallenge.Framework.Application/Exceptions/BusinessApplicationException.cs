using System;

namespace UChallenge.Framework.Application.Exceptions
{
    public abstract class BusinessApplicationException :
        Exception
    {
        public BusinessApplicationException(string message) :
            base(message)
        {

        }
    }
}
