using System;

namespace UChallenge.Framework.Domain.ValueObjects
{
    internal interface IEquatableValueObject<TValueObject> :
        IEquatable<TValueObject>
        where TValueObject : struct
    {
    }
}
