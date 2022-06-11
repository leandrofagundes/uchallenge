namespace UChallenge.Framework.Domain.Models
{
    public abstract record BaseEntity<TUniqueIdentifier> :
        IAggregateRoot
        where TUniqueIdentifier : struct
    {
        public TUniqueIdentifier Id { get; protected set; }
    }
}
