namespace UChallenge.Framework.Domain.Exceptions
{
    public abstract class DomainFieldException :
        DomainException
    {
        public DomainFieldException(string message) : 
            base(message)
        {

        }
    }
}
